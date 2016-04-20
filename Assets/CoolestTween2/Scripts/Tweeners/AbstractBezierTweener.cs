using UnityEngine;

namespace CoolestTween {

	public abstract class AbstractBezierTweener : AbstractTweener{

		private BezierPath path;

		public BezierPath Path {
			get {
				return path;
			}
		}

		public AbstractBezierTweener(Vector3[] waypoints) {
			path = new BezierPath(waypoints);
		}

		public Vector3 GetPoint(float v){
			return path.getPoint(v);
		}
	}
}