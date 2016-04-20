using UnityEngine;

namespace CoolestTween {
	public class UnityFrameUpdater : FrameUpdater{

		private FrameUpdaterComponent component;

		public UnityFrameUpdater(){
			component = new GameObject("FrameUpdater").AddComponent<FrameUpdaterComponent>();
			GameObject.DontDestroyOnLoad(component.gameObject);
			component.Initialize(this);
		}

		private class FrameUpdaterComponent : MonoBehaviour{
			private UnityFrameUpdater updater;
			public void Initialize(UnityFrameUpdater updater){
				this.updater = updater;
			}

			private void Update(){
				if(updater.frameUpdateEvent != null){
					updater.frameUpdateEvent();
				}
			}
		}
	}
}