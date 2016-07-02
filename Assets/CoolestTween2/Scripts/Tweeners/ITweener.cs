namespace CoolestTween {

	public interface ITweener{

		void Init(TweenBuilder builder);
		void Swap();
		void Update(float v);
	}
}