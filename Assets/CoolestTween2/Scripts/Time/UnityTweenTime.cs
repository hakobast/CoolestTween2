namespace CoolestTween {

	public class UnityTweenTime : TweenTime{

		public float Time{
			get{
				return UnityEngine.Time.time;
			}
		}
	}
}