using UnityEngine;

namespace CoolestTween {

	public class BezierCurve {
		public Vector3 startP;
		public Vector3 endP;
		public Vector3 controlP1,controlP2;
		public float length;
		public float smoothness = 0.05f;
		public int segments;

		public BezierCurve(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float smoothness = 0.05f) {
			this.startP = p1;
			this.controlP1 = p2;
			this.controlP2 = p3;
			this.endP = p4;
			this.smoothness = smoothness;
			this.segments = (int)(1f/smoothness);

			Vector3 lastV = getPoint(0);
			Vector3 v;
			for(int i = 1; i < segments; i++) {
				v = getPoint((float)i/segments);
				length += (lastV-v).magnitude;
				lastV = v;
			}
		}

		public Vector3 getPoint(float t) {
			float a = (1-t);
			float aa = a*a;
			float aaa = aa*a;
			float tt = t*t;
			float ttt = tt*t;

			return aaa*startP + 3*aa*t*controlP1 + 3*a*tt*controlP2 + ttt*endP;
		}

		public Vector3[] getAll() {
			Vector3[] points = new Vector3[segments+1];
			for(int i = 0; i < segments; i++) {
				points[i] = getPoint((float)i/segments);
			}
			points[points.Length-1] = getPoint(1f);

			return points;
		}
	}
}