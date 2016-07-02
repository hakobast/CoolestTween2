using UnityEngine;
using System.Collections.Generic;

namespace CoolestTween {

	public class Tween {

		public delegate void Handler();

		private TweenTime timeProvider;
		private ITweener tweener;
		private EaseType easeType;
		private TweenType tweenType;
		private IEaseFunction easeFunction;
		private TweenHandler tweenHandler;
		private Handler handler;
		private float duration;
		private int count;
		private bool isPause;
		private float realTime;
		private float startTime;
		private float pauseTime;
		private float delayTime;
		private LinkedListNode<Tween> node;

		public bool IsComplete {
			get{
				return Time >= duration;
			}
		}

		public bool IsPause {
			get {
				return isPause;
			}
		}

		public bool InDelay {
			get{
				return delayTime > 0 && (realTime - startTime) < delayTime + pauseTime;
			}
		}

		public LinkedListNode<Tween> Node {
			get {
				if(node == null){
					this.node = new LinkedListNode<Tween>(this);
				}
				return node;
			}
		}

		private float Time{
			get{
				return realTime - (startTime + delayTime + pauseTime);
			}
		}

		public Tween(){
		}

		public Tween(TweenTime timeProvider, TweenBuilder builder){
			Init(timeProvider, builder);
		}

		public void Init(TweenTime timeProvider, TweenBuilder builder){
			this.timeProvider = timeProvider;
			this.tweener = builder.Tweener;
			this.easeType = builder.EaseType;
			this.tweenType = builder.TweenType;
			this.easeFunction = builder.EaseFunction;
			this.duration = builder.Duration;
			this.delayTime = builder.Delay;
			this.handler = builder.Handler;
			this.startTime = 0;
			this.realTime = 0;
			this.pauseTime = 0;
		}

		public void Start(){
			startTime = timeProvider.Time;
		}

		public void Pause(){
			if(!IsPause){
				isPause = true;
			}
		}

		public void Resume(){
			if(IsPause){
				pauseTime += (timeProvider.Time - realTime);
				isPause = false;
			}
		}

		public void Update(){
			if(IsPause){
				return;
			}

			if(IsComplete){
				return;
			}

			realTime = timeProvider.Time;
			if(!InDelay){
				tweener.Update(Time);
				if(IsComplete){
					processComplete();
				}
			}
		}

		public TweenHandler GetHandler(){
			if(tweenHandler == null){
				tweenHandler = new TweenHandler();
			}
			tweenHandler.SetTween(this);
			return tweenHandler;
		}

		private bool processComplete(){
			switch(tweenType){
				case TweenType.Once:{
					invokeComplete();
					return true;
				}
				case TweenType.Loop:{
					startTime = timeProvider.Time;
					pauseTime = 0.0f;
					delayTime = 0.0f;
					count++;
					return false;
				}
				case TweenType.PingPong:{
					startTime = timeProvider.Time;
					pauseTime = 0.0f;
					delayTime = 0.0f;
					count++;
					tweener.Swap();
					return false;
				}
				default:{
					return true;
				}
			}
		}

		private void invokeComplete(){
			if(handler != null){
				handler();
			}
		}
	}
}