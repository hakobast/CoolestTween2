using UnityEngine;

namespace CoolestTween {

	public abstract class AbstractBezierTweener : AbstractTweener<Vector3>{

		private BezierPath path;
		private bool forward;

		public BezierPath Path {
			get {
				return path;
			}
		}

		public AbstractBezierTweener(Vector3[] waypoints) {
			path = new BezierPath(waypoints);
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