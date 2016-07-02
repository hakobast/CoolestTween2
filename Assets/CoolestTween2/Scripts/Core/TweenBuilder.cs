namespace CoolestTween {

	public class TweenBuilder {
		private ITweener tweener;
		private EaseType easeType;
		private TweenType tweenType;
		private IEaseFunction easeFunction;
		private float duration;
		private float delay;
		private bool unscaledTime;
		private Tween.Handler handler;

		public ITweener Tweener {
			get {
				return tweener;
			}
		}

		public EaseType EaseType {
			get {
				return easeType;
			}
		}

		public TweenType TweenType {
			get {
				return tweenType;
			}
		}

		public IEaseFunction EaseFunction {
			get {
				return easeFunction;
			}
		}

		public float Duration {
			get {
				return duration;
			}
		}

		public float Delay {
			get {
				return delay;
			}
		}

		public bool UnscaledTime {
			get {
				return unscaledTime;
			}
		}

		public Tween.Handler Handler{
			get{
				return handler;
			}
		}

		public TweenBuilder WithDuration(float duration){
			this.duration = duration;
			return this;
		}

		public TweenBuilder WithEase(EaseType easeType){
			this.easeType = easeType;
			return this;
		}

		public TweenBuilder WithTweenType(TweenType tweenType){
			this.tweenType = tweenType;
			return this;
		}

		public TweenBuilder WithTweener(ITweener accessor){
			this.tweener = accessor;
			return this;
		}

		public TweenBuilder WithEaseFunction(IEaseFunction easeFunction){
			this.easeFunction = easeFunction;
			return this;
		}

		public TweenBuilder WithUnscaledTime(bool unscaledTime){
			this.unscaledTime = unscaledTime;
			return this;
		}

		public TweenBuilder WithDelay(float delay){
			this.delay = delay;
			return this;
		}

		public TweenBuilder WithHandler(Tween.Handler handler){
			this.handler = handler;
			return this;
		}
	}
}
