using UnityEngine;

namespace CoolestTween {

	public class TrPositionBezierTweener : AbstractBezierTweener {

		private Transform transform;
		public TrPositionBezierTweener(Transform transform, Vector3[] waypoints) : base(waypoints){
			this.transform = transform;
		}

		public override void Update(float v) {
			transform.position = GetPoint(v);
		}
	}
}