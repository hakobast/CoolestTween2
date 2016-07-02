using UnityEngine;
using CoolestTween;
using System.Collections;

public class BenchmarkTest : MonoBehaviour {

	[SerializeField] private int count;
	[SerializeField] private Transform prefab;
	[SerializeField] private EaseType easeType;
	[SerializeField] private TweenType tweenType;
	[SerializeField] private float duration;
	[SerializeField] private float delay;
	[SerializeField] private bool randomDuration;
	[SerializeField] private float radius = 5.0f;
	[SerializeField] private bool periodic = true;


	// Use this for initialization
	void Start () {

		for (int i = 0; i < count; i++) {
			Transform tr = Instantiate<Transform>(prefab);

			tr.MoveTo(Random.insideUnitSphere * radius, new TweenBuilder()
			.WithEase(easeType)
			.WithTweenType(tweenType)
			.WithDuration(randomDuration ? Random.Range(0.5f, 2.0f) : duration)
			.WithDelay(delay)
			);

			if(tr.GetComponent<Renderer>()) {
				tr.GetComponent<Renderer>().material.MainColorTo(Color.Lerp(Color.blue, Color.green, Random.Range(0.0f, 1.0f)),
					 new TweenBuilder()
					.WithEase(easeType)
					.WithTweenType(tweenType)
					.WithDuration(randomDuration ? Random.Range(0.5f, 2.0f) : duration)
					.WithDelay(delay)
				);
			}
		}

		if(periodic){
			StartCoroutine(animate());
		}
	}

	IEnumerator animate(){
		while(true){

			yield return new WaitForSeconds(0.1f);

			for (int i = 0; i < count; i++) {
				Transform tr = Instantiate<Transform>(prefab);

				tr.MoveTo(Random.insideUnitSphere * radius, new TweenBuilder()
				.WithEase(easeType)
				.WithTweenType(tweenType)
				.WithDuration(randomDuration ? Random.Range(0.5f, 2.0f) : duration)
				.WithDelay(delay)
				);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
