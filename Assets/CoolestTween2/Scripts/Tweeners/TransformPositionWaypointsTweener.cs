using UnityEngine;

namespace CoolestTween {
	public class TransformPositionWaypointsTweener : AbstractTweener {

		private Transform transform;
		private Waypoints path;

		public TransformPositionWaypointsTweener(Transform transform, Vector3[] waypoints){
			this.transform = transform;
			this.path = new Waypoints(waypoints);
		}

		public override void Update(float v) {
			float t = Ease(v, 0.0f, 1.0f, Duration);
			transform.position = path.getPoint(t);
		}
	}
}