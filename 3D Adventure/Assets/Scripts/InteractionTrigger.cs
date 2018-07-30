using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	public class InteractionTrigger : MonoBehaviour
	{
		// Variables
		[SerializeField] LayerMask mask;
		[SerializeField] float interactionDistance;
		[Space]
		[Header("Output")]
		[SerializeField] BoolVariableReference canUse;
		[SerializeField] BoolVariableReference outOfRange;
		[SerializeField] InteractionDataVariableReference interactionData;

		bool inRange;
		bool isInteractible;

		Transform currentTransform;
		IInteractible currentInteractible;

		// Functions
		private void Update ()
		{
			TestUnderCursor();

			canUse.Value = inRange && isInteractible;
			outOfRange.Value = isInteractible && !inRange;

			if (Input.GetMouseButtonDown(0)) {
				TriggerInteraction();
			}
		}

		private void TestUnderCursor ()
		{
			RaycastHit hit;
			Physics.Raycast(transform.position, transform.forward, out hit, 10000, mask);

			if (currentTransform != hit.transform) {
				Debug.Log(":OnScreen:New interaction target");
				currentTransform = hit.transform;
				if (currentTransform != null) {
					currentInteractible = currentTransform.GetComponent<IInteractible>();

					if (currentInteractible != null) {
						interactionData.Value.InteractionText = currentInteractible.InteractionText;
						isInteractible = true;
					} else {
						isInteractible = false;
					}
				} else {
					isInteractible = false;
				}
			}
			if (isInteractible) {
				if ((transform.position - hit.point).sqrMagnitude < Mathf.Pow(interactionDistance * currentInteractible.InteractionDistanceMultiplier, 2)) {
					inRange = true;
				} else {
					inRange = false;
				}
			} else {
				inRange = false; 
			}
		}

		//Debug.Log((transform.position - hit.point).sqrMagnitude + "<" + (interactionDistance * interactionDistance));
		//if((transform.position - hit.point).sqrMagnitude < (interactionDistance * interactionDistance)) {
		//	canUse.Value = true;
		//}

		public void TriggerInteraction ()
		{
			if (canUse.Value) {
				currentInteractible.Interact();
			}
		}


		private void OnDrawGizmosSelected ()
		{
			Gizmos.DrawWireSphere(transform.position, interactionDistance);
		}
	}
}