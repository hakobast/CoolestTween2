using UnityEngine;
using UnityEngine.UI;

namespace CoolestTween {

	public class MaterialFloatTweener : AbstractTweener<float> {

		private Material material;
		private string propertyName;
		private float value;

		public MaterialFloatTweener(Material material, string propertyName, float to){
			this.material = material;
			this.propertyName = propertyName;
			this.From = material.GetFloat(propertyName);
			this.To = to;
		}

		public override void Update(float v) {
			float diff = To-From;
			value = Ease(v, From, diff, Duration);
			material.SetFloat(propertyName, value);
		}
	}
}