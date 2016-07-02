using UnityEngine;

namespace CoolestTween {

	public class TrAnchorPositionTweener : AbstractTweener<Vector2>{

		private RectTransform transform;
		private Vector2 value;

		public TrAnchorPositionTweener(RectTransform transform, Vector2 to) {
			this.transform = transform;
			this.From = transform.anchoredPosition;
			this.To = to;
		}

		public override void Update(float v) {
			Vector2 dif = To-From;
			value.x = Ease(v, From.x, dif.x, Duration);
			value.y = Ease(v, From.y, dif.y, Duration);
			transform.anchoredPosition = value;
		}
	}
}