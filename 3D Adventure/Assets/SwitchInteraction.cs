using UnityEngine;
using UnityEngine.Events;

namespace Wokarol
{
	public class SwitchInteraction : MonoBehaviour, IInteractible
	{
		// Variables
		public string InteractionText {
			get {
				return "Switch";
			}
		}
		public float InteractionDistanceMultiplier {
			get {
				return 2;
			}
		}

		[SerializeField] bool state = true;
		[SerializeField] UnityEvent onOn;
		[SerializeField] UnityEvent onOff;
		// Functions

		private void Start ()
		{
			TriggerState(state);
		}

		public void Interact ()
		{
			state = !state;
			TriggerState(state);
		}

		void TriggerState(bool _state)
		{
			if (_state) {
				onOn.Invoke();
			} else {
				onOff.Invoke();
			}
		}
	}
}