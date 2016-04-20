using UnityEngine;
using CoolestTween;
using Core;

public class Test : MonoBehaviour{

	public Vector3 dest;
	public Vector2 dest2D;

	public Vector3[] waypoints;


	public float duration;
	public float delay;
	public EaseType easeType;
	public TweenType tweenType;

	private TweenHandler tween;

	void Start(){

		if(transform is RectTransform){
			tween = CoolestTween2.I.CreateTween(new TweenBuilder()
				.WithEase(easeType)
				.WithTweenType(tweenType)
				.WithDuration(duration)
				.WithDelay(delay)
				.WithTweener(new RectAnchorPositionTweener(transform as RectTransform, dest2D))
			);
		}else{
			if(waypoints.Length >= 2){
				tween = CoolestTween2.I.MoveToBezier(transform, waypoints, new TweenBuilder()
					.WithEase(easeType)
					.WithTweenType(tweenType)
					.WithDuration(duration)
					.WithDelay(delay)
				);
			}else{
				tween = CoolestTween2.I.MoveTo(transform, dest, new TweenBuilder()
					.WithEase(easeType)
					.WithTweenType(tweenType)
					.WithDuration(duration)
					.WithDelay(delay)
				);
			}
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