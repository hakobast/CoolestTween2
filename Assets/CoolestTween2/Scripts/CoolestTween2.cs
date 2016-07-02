using UnityEngine;
using System.Collections.Generic;

namespace CoolestTween {

	public class CoolestTween2{

		private const int InitialCacheSize = 100;

		private FrameUpdater frameUpdater;
		private TweenTime time;
		private TweenTime unscaledTime;
		private Queue<Tween> cachedTweens;
		private LinkedList<Tween> tweens;

		private static CoolestTween2 i;
		private static CoolestTween2 I{
			get{
				if(i == null){
					i = new CoolestTween2();
				}

				return i;
			}
		}

		public static TweenHandler CreateTween(TweenBuilder builder){
			builder.Tweener.Init(builder);
			Tween tween = I.getTween(builder);
			tween.Start();
			return tween.GetHandler();
		}

		private CoolestTween2(){
			time = new UnityTweenTime();
			unscaledTime = new UnityUnscaledTweenTime();
			frameUpdater = new UnityFrameUpdater();
			tweens = new LinkedList<Tween>();
			cachedTweens = new Queue<Tween>(InitialCacheSize);

			for(int i = 0; i < InitialCacheSize; i++){
				cachedTweens.Enqueue(new Tween());
			}

			frameUpdater.SetFrameUpdateEvent(update);
		}

		private Tween getTween(TweenBuilder builder){
			if(builder.EaseFunction == null){
				builder.WithEaseFunction(EaseFunctions.GetEaseFunction(builder.EaseType));
			}

			Tween tween = null;
			if(cachedTweens.Count > 0){
				tween = cachedTweens.Dequeue();
			}else{
				tween = new Tween();
			}

			if(builder.UnscaledTime){
				tween.Init(unscaledTime, builder);
			}else{
				tween.Init(time, builder);
			}
			tweens.AddLast(tween.Node);
			return tween;
		}

		private void update(){
			var node = tweens.First;
			while (node != null) {
				node.Value.Update();
				var nextNode = node.Next;
				if (node.Value.IsComplete) {
					tweens.Remove(node);
					cachedTweens.Enqueue(node.Value);
				}
				node = nextNode;
			}
		}
	}
}