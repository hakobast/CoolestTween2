using UnityEngine;

namespace CoolestTween {
	public class TransformPositionBezierTweener : AbstractBezierTweener {

		private Transform transform;
		public TransformPositionBezierTweener(Transform transform, Vector3[] waypoints) : base(waypoints){
			this.transform = transform;
		}

		public override void Update(float v) {
			float t = Ease(v, 0.0f, 1.0f, Duration);
			transform.position = GetPoint(t);
		}
	}
}