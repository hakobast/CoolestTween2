namespace CoolestTween {
	public static class EaseFunctions {

		public static IEaseFunction GetEaseFunction(EaseType type) {
			switch(type){
				case EaseType.Linear:{
					return Linear;
				}
				case EaseType.EaseInQuad:{
					return EaseInQuad;
				}
				case EaseType.EaseOutQuad:{
					return EaseOutQuad;
				}
				default: {
					return Linear;
				}
			}
		}

		public static float Linear(float t, float b, float c, float d) {
			return c * t / d + b;
		}

		public static float EaseInQuad(float t, float b, float c, float d) {
			return c * (t/=d) * t + b;
		}

		public static float EaseOutQuad(float t, float b, float c, float d) {
			return -c *(t/=d)*(t-2) + b;
		}
	}
}