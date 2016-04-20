using Core;

namespace CoolestTween {

	public class Tween {

		private TweenTime timeProvider;
		private ITweener tweener;
		private EaseType easeType;
		private TweenType tweenType;
		private IEaseFunction easeFunction;
		private float duration;

		private int direction;
		private int count;
		private float realTime;
		private float startTime;
		private float pauseTime;
		private float delayTime;

		private bool isPause;

		public bool IsComplete {
			get{
				return direction == 1 ?
				Time >= duration :
				Time <= 0;
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

		private float Time{
			get{
				return direction == 1 ?
				realTime - (startTime + delayTime + pauseTime) :
				(startTime + delayTime + pauseTime + duration) - realTime;
			}
		}

		public Tween(TweenTime timeProvider, TweenBuilder builder){
			this.timeProvider = timeProvider;
			this.tweener = builder.Tweener;
			this.easeType = builder.EaseType;
			this.tweenType = builder.TweenType;
			this.easeFunction = builder.EaseFunction;
			this.duration = builder.Duration;
			this.delayTime = builder.Delay;
			this.direction = 1;
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
				if(processComplete()){
					return;
				}
			}

			realTime = timeProvider.Time;
			if(!InDelay){
				tweener.Update(Time);
			}
		}

		private bool processComplete(){
			switch(tweenType){
				case TweenType.Once:{
					return true;
				}
				case TweenType.Loop:{
					startTime = timeProvider.Time;
					delayTime = 0.0f;
					count++;
					return false;
				}
				case TweenType.PingPong:{
					startTime = timeProvider.Time;
					delayTime = 0.0f;
					direction *= -1;
					count++;
					return false;
				}
				default:{
					return true;
				}
			}
		}
	}
}