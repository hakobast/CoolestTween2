using UnityEngine;

namespace CoolestTween {

	public class BezierPath {
		private Vector3[] controllPoints;
		private BezierCurve[] curves;
		private float[] curveParts;
		private float length;
		private int curvesCount;

		public BezierPath(Vector3[] points) {
			if(points.Length < 4)
				Debug.LogError("Bezier points count must be 4 or more");
			if(points.Length%4 != 0)
				Debug.LogError("Bezier points must be sets of 4 points");

			controllPoints = points;
			curvesCount = points.Length/4;
			curves = new BezierCurve[curvesCount];
			curveParts = new float[curvesCount];

			for(int i = 0; i < curvesCount; i++) {
				curves[i] = new BezierCurve(
					controllPoints[i*4 + 0],
					controllPoints[i*4 + 1],
					controllPoints[i*4 + 2],
					controllPoints[i*4 + 3]
				);
				length += curves[i].length;
			}

			for(int i = 0; i < curvesCount; i++) {
				curveParts[i] = curves[i].length/length;
			}
		}

		public Vector3 getPoint(float t) {
			float sum = 0;
			for(int i = 0; i < curvesCount; i++){
				sum += curveParts[i];
				if(t < sum)
					return curves[i].getPoint((t+curveParts[i]-sum) /curveParts[i]);
			}
			return curves[curvesCount-1].getPoint(1f);
		}
	}
}