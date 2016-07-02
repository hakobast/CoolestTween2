using UnityEngine;

namespace CoolestTween {

	public class TrPositionWaypointsTweener : AbstractWaypointTweener {

		private Transform transform;
		public TrPositionWaypointsTweener(Transform transform, Vector3[] waypoints) : base(waypoints){
			this.transform = transform;
		}

		public override void Update(float v) {
			transform.position = GetPoint(v);
		}
	}
}