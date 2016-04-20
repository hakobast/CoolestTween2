using UnityEngine;
using System.Collections.Generic;

namespace CoolestTween {

	public class CoolestTween2{

		private FrameUpdater frameUpdater;
		private TweenTime time;
		private TweenTime unscaledTime;
		private List<Tween> tweens;

		private static CoolestTween2 i;
		public static CoolestTween2 I{
			get{
				if(i == null){
					i = new CoolestTween2();
				}

				return i;
			}
		}

		private CoolestTween2(){
			time = new UnityTweenTime();
			unscaledTime = new UnityUnscaledTweenTime();
			frameUpdater = new UnityFrameUpdater();
			tweens = new List<Tween>();

			frameUpdater.SetFrameUpdateEvent(update);
		}

		public TweenHandler MoveTo(Transform transform, Vector3 dest, TweenBuilder builder) {
			if(builder.Tweener == null){
				builder.WithTweener(new TransformPositionTweener(transform, dest));
			}

			return CreateTween(builder);
		}

		public TweenHandler MoveToWaypoins(Transform transform, Vector3[] points, TweenBuilder builder) {
			if(builder.Tweener == null){
				builder.WithTweener(new TransformPositionWaypointsTweener(transform, points));
			}

			return CreateTween(builder);
		}

		public TweenHandler MoveToBezier(Transform transform, Vector3[] points, TweenBuilder builder) {
			if(builder.Tweener == null){
				builder.WithTweener(new TransformPositionBezierTweener(transform, points));
			}

			return CreateTween(builder);
		}

		public TweenHandler CreateTween(TweenBuilder builder){
			builder.Tweener.Init(builder);
			Tween tween = getTween(builder);
			tween.Start();
			return new TweenHandler(tween);
		}

		private Tween getTween(TweenBuilder builder){
			if(builder.EaseFunction == null){
				builder.WithEaseFunction(EaseFunctions.GetEaseFunction(builder.EaseType));
			}

			Tween tween = null;
			if(builder.UnscaledTime){
			    tween = new Tween(unscaledTime, builder);
			}else{
				tween = new Tween(time, builder);
			}

			tweens.Add(tween);

			return tween;
		}

		private void update(){
			for(int i = 0, l = tweens.Count; i < l; i++){
				tweens[i].Update();
			}
		}
	}
}