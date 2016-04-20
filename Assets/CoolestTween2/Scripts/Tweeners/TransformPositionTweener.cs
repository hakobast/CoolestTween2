using UnityEngine;

namespace CoolestTween {
	public class TransformPositionTweener : AbstractTweener {

		private Transform transform;
		private Vector3 from;
		private Vector3 to;
		private Vector3 diff;
		private Vector3 value;

		public TransformPositionTweener(Transform transform, Vector3 to){
			this.transform = transform;
			this.from = transform.position;
			this.to = to;
			this.diff = this.to-this.from;
		}

		public override void Update(float v) {
			value.x = Ease(v, from.x, diff.x, Duration);
			value.y = Ease(v, from.y, diff.y, Duration);
			value.z = Ease(v, from.z, diff.z, Duration);
			transform.position = value;
		}
	}
}