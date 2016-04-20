using UnityEngine;

namespace CoolestTween {
	public class RectAnchorPositionTweener : AbstractTweener{

		private RectTransform transform;
		private Vector2 from;
		private Vector2 to;
		private Vector2 dif;
		private Vector2 value;

		public RectAnchorPositionTweener(RectTransform transform, Vector2 to) {
			this.transform = transform;
			this.from = transform.anchoredPosition;
			this.to = to;
			this.dif = to-from;
		}

		public override void Update(float v) {
			value.x = Ease(v, from.x, dif.x, Duration);
			value.y = Ease(v, from.y, dif.y, Duration);

			transform.anchoredPosition = value;
		}
	}
}