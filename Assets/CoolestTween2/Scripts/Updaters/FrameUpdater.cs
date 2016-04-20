namespace CoolestTween {
	public abstract class FrameUpdater {

		public delegate void OnFrameUpdate();

		protected OnFrameUpdate frameUpdateEvent;

		public void SetFrameUpdateEvent(OnFrameUpdate handler){
			this.frameUpdateEvent = handler;
		}
	}
}