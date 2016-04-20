namespace CoolestTween{

	public abstract class AbstractTweener : ITweener{

		private TweenBuilder builder;

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

		public abstract void Update(float v);
	}
}