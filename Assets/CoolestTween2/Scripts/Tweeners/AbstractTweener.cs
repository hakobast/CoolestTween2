namespace CoolestTween{

	public abstract class AbstractTweener<T> : ITweener{

		private TweenBuilder builder;

		public T To {
			get {
				return to;
			}
			set {
				to = value;
			}
		}

		public T From {
			get {
				return from;
			}
			set {
				from = value;
			}
		}

		private T from;
		private T to;

		public float Duration {
			get{
				return builder.Duration;
			}
		}

		public IEaseFunction Ease {
			get{
				return builder.EaseFunction;
			}
		}

		public void Init(TweenBuilder builder) {
			this.builder = builder;
		}

		public virtual void Swap() {
			T temp = From;
			From = To;
			To = temp;
		}

		public abstract void Update(float v);
	}
}