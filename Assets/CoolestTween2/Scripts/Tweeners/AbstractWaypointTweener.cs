using UnityEngine;

namespace CoolestTween {

	public abstract class AbstractWaypointTweener : AbstractTweener<Vector3>{

		private Waypoints path;
		private bool forward;

		public Waypoints Path {
			get {
				return path;
			}
		}

		public AbstractWaypointTweener(Vector3[] waypoints) {
			path = new Waypoints(waypoints);
			forward = true;
		}

		public Vector3 GetPoint(float v){
			float t = 0.0f;
			if(forward){
				t = Ease(v, 0.0f, 1.0f, Duration);
			}else{
				t = Ease(v, 1.0f, -1.0f, Duration);
			}
			return path.getPoint(t);
		}

		public override void Swap() {
			forward = !forward;
		}
	}
}