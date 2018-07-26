using UnityEngine;
using UnityEngine.Events;

namespace Wokarol
{
	public class CamSwitchOnKey : MonoBehaviour 
	{
		// Variables
		[SerializeField] bool FPP;
		[SerializeField] KeyCode key;
		[Space]
		[SerializeField] UnityEvent FPPEvent;
		[SerializeField] UnityEvent TPPEvent;
		// Functions

		private void Start ()
		{
			if (FPP) {
				FPPEvent.Invoke();
			} else {
				TPPEvent.Invoke();
			}
		}

		private void Update ()
		{
			if (Input.GetKeyDown(key)) {
				if (FPP) {
					TPPEvent.Invoke();
					FPP = false;
				} else {
					FPPEvent.Invoke();
					FPP = true;
				}
			}
		}
	}
}