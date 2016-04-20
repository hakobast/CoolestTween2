using UnityEngine;

namespace CoolestTween {

	public class Waypoints
	{
		public Vector3[] points;
		public float[] parts;
		public float length;

		public Waypoints(Vector3[] points) {
			this.points = points;

			if(points.Length < 2)
				Debug.LogError("Waypoint count must be 2 or more");

			parts = new float[points.Length-1];
			for(int i = 0; i < points.Length-1; i++){
				length += (points[i]-points[i+1]).magnitude;
			}

			for(int i = 0; i < points.Length-1; i++){
				parts[i] = (points[i]-points[i+1]).magnitude/length;
			}
		}

		public Vector3 getPoint(float t) {
			float sum = 0;
			for(int i = 0; i < points.Length-1; i++){
				sum += parts[i];
				if(t < sum){
					return points[i] + (points[i+1]-points[i])*((t+parts[i]-sum) /parts[i]);
				}
			}
			return points[points.Length-1];
		}

		public Vector3[] getAll() {
			int segments = (int)(1f/0.03f);

			Vector3[] points = new Vector3[segments+1];

			for(int i = 0; i < segments; i++) {
				points[i] = getPoint((float)i/segments);
			}
			points[points.Length-1] = getPoint(1f);
			return points;
		}
	}
}