using UnityEngine;
using UnityEngine.UI;

namespace CoolestTween {

	public class SpriteColorTweener : AbstractTweener<Vector4> {

		private SpriteRenderer spriteRend;
		private Vector4 value;

		public SpriteColorTweener(SpriteRenderer image, Color to){
			this.spriteRend = image;
			this.From = image.color;
			this.To = to;
		}

		public override void Update(float v) {
			Vector4 diff = To-From;
			value.x = Ease(v, From.x, diff.x, Duration);
			value.y = Ease(v, From.y, diff.y, Duration);
			value.z = Ease(v, From.z, diff.z, Duration);
			value.w = Ease(v, From.w, diff.w, Duration);
			spriteRend.color = value;
		}
	}
}