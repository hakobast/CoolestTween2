using UnityEngine;
using UnityEngine.UI;

namespace CoolestTween {

	public class MaterialColorTweener : AbstractTweener<Vector4> {

		private Material material;
		private string propertyName;
		private Vector4 value;

		public MaterialColorTweener(Material material, string propertyName, Color to){
			this.material = material;
			this.propertyName = propertyName;
			this.From = material.GetColor(propertyName);
			this.To = to;
		}

		public override void Update(float v) {
			Vector4 diff = To-From;
			value.x = Ease(v, From.x, diff.x, Duration);
			value.y = Ease(v, From.y, diff.y, Duration);
			value.z = Ease(v, From.z, diff.z, Duration);
			value.w = Ease(v, From.w, diff.w, Duration);
			material.SetColor(propertyName, value);
		}
	}
}