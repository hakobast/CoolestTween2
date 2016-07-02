using UnityEngine;
using CoolestTween;
using UnityEngine.UI;

public class Test : MonoBehaviour{

	public Vector3 dest;
	public Vector2 dest2D;
	public Vector3[] waypoints;
	public Color color;
	public float duration;
	public float delay;
	public EaseType easeType;
	public TweenType tweenType;

	private TweenHandler tween;

	void Start(){
		if(transform is RectTransform){
			tween = (transform as RectTransform).ChangeSizeDelta(dest2D, new TweenBuilder()
			.WithEase(easeType)
			.WithTweenType(tweenType)
			.WithDuration(duration)
			.WithDelay(delay));
		}else{
			if(waypoints.Length >= 2){
				tween = transform.MoveToBezier(waypoints, new TweenBuilder()
					.WithEase(easeType)
					.WithTweenType(tweenType)
					.WithDuration(duration)
					.WithDelay(delay)
				);
			}else{
				tween = transform.MoveTo(dest, new TweenBuilder()
					.WithEase(easeType)
					.WithTweenType(tweenType)
					.WithDuration(duration)
					.WithDelay(delay)
					.WithHandler(delegate  {
					Debug.Log("Move complete");
					})
				);
			}
		}

		if(GetComponent<Image>()) {
			tween = GetComponent<Image>().ColorTo(color, new TweenBuilder()
			.WithEase(easeType)
			.WithTweenType(tweenType)
			.WithDuration(duration)
			.WithDelay(delay));
		}

		if(GetComponent<SpriteRenderer>()) {
			tween = GetComponent<SpriteRenderer>().ColorTo(color, new TweenBuilder()
			.WithEase(easeType)
			.WithTweenType(tweenType)
			.WithDuration(duration)
			.WithDelay(delay)
			.WithHandler(delegate  {
				Debug.Log("Color complete");
			}));
		}
	}

	void Update(){
	    if(Input.GetKeyDown(KeyCode.P)){
	        tween.Pause();
	    }

		if(Input.GetKeyDown(KeyCode.R)){
	        tween.Resume();
	    }
	}
}