namespace CoolestTween {

	public class UnityUnscaledTweenTime : TweenTime{

		public float Time{
			get{
				return UnityEngine.Time.unscaledTime;
			}
		}
	}
}