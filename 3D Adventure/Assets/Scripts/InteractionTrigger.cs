using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	public class InteractionTrigger : MonoBehaviour 
	{
		// Variables
		[SerializeField] LayerMask mask;

		// Functions
		private void Update ()
		{
			if (Input.GetMouseButtonDown(0)) {
				TriggerInteraction();
			}
		}

		public void TriggerInteraction ()
		{
			RaycastHit hit;
			if(Physics.Raycast(transform.position, transform.forward, out hit, 1000, mask)) {
				IInteractible interactible = hit.transform.GetComponent<IInteractible>();
				if (interactible == null) {
					return;
				}
				interactible.Interact();
			}
		}
	}
}