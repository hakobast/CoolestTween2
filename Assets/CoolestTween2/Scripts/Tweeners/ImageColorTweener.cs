using UnityEngine;
using UnityEngine.UI;

namespace CoolestTween {

	public class ImageColorTweener : AbstractTweener<Vector4> {

		private Image image;
		private Vector4 value;

		public ImageColorTweener(Image image, Color to){
			this.image = image;
			this.From = image.color;
			this.To = to;
		}

		public override void Update(float v) {
			Vector4 diff = To-From;
			value.x = Ease(v, From.x, diff.x, Duration);
			value.y = Ease(v, From.y, diff.y, Duration);
			value.z = Ease(v, From.z, diff.z, Duration);
			value.w = Ease(v, From.w, diff.w, Duration);
			image.color = value;
		}
	}
}