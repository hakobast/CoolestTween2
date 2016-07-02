using UnityEngine;
using UnityEngine.UI;

namespace CoolestTween {

	public static class TweenExtensions {

		/* Transform tweens */
		public static TweenHandler MoveTo(this Transform transform, Vector3 dest, TweenBuilder builder){
			builder.WithTweener(new TrPositionTweener(transform, dest));
			return CoolestTween2.CreateTween(builder);
		}

		public static TweenHandler ScaleTo(this Transform transform, Vector3 dest, TweenBuilder builder){
			builder.WithTweener(new TrScaleTweener(transform, dest));
			return CoolestTween2.CreateTween(builder);
		}

		public static TweenHandler RotateTo(this Transform transform, Vector3 dest, TweenBuilder builder){
			builder.WithTweener(new TrRotationTweener(transform, dest));
			return CoolestTween2.CreateTween(builder);
		}

		/* Path tweens */
		public static TweenHandler MoveToBezier(this Transform transform, Vector3[] path, TweenBuilder builder){
			builder.WithTweener(new TrPositionBezierTweener(transform, path));
			return CoolestTween2.CreateTween(builder);
		}

		public static TweenHandler MoveToWaypoints(this Transform transform, Vector3[] path, TweenBuilder builder){
			builder.WithTweener(new TrPositionWaypointsTweener(transform, path));
			return CoolestTween2.CreateTween(builder);
		}

		/* RectTransform tweens */
		public static TweenHandler MoveToAnchor(this RectTransform transform, Vector2 dest, TweenBuilder builder){
			builder.WithTweener(new TrAnchorPositionTweener(transform, dest));
			return CoolestTween2.CreateTween(builder);
		}

		public static TweenHandler ChangeSizeDelta(this RectTransform transform, Vector2 dest, TweenBuilder builder){
			builder.WithTweener(new TrSizeDeltaTweener(transform, dest));
			return CoolestTween2.CreateTween(builder);
		}

		/* Color tweens */
		public static TweenHandler ColorTo(this Image image, Color dest, TweenBuilder builder){
			builder.WithTweener(new ImageColorTweener(image, dest));
			return CoolestTween2.CreateTween(builder);
		}

		public static TweenHandler ColorTo(this SpriteRenderer spriteRenderer, Color dest, TweenBuilder builder){
			builder.WithTweener(new SpriteColorTweener(spriteRenderer, dest));
			return CoolestTween2.CreateTween(builder);
		}

		public static TweenHandler MainColorTo(this Material material, Color dest, TweenBuilder builder){
			builder.WithTweener(new MaterialColorTweener(material, "_Color", dest));
			return CoolestTween2.CreateTween(builder);
		}

		public static TweenHandler ColorTo(this Material material, string propertyName, Color dest, TweenBuilder builder){
			builder.WithTweener(new MaterialColorTweener(material, propertyName, dest));
			return CoolestTween2.CreateTween(builder);
		}

		/* Value tweens */
		public static TweenHandler FloatTo(this Material material, string propertyName, float dest, TweenBuilder builder){
			builder.WithTweener(new MaterialFloatTweener(material, propertyName, dest));
			return CoolestTween2.CreateTween(builder);
		}
	}
}