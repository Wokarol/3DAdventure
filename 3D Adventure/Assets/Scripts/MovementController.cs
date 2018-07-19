using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	[RequireComponent(typeof(Rigidbody))]
	public class MovementController : MonoBehaviour
	{
		// Variables
		public float speed = 4;
		public float nonForwardSpeedMultiplier = 0.5f;

		public float slowWalkMultiplier = 0.5f;
		public float sprintMultiplier = 2f;

		//[Tooltip("Calculated based on dot product of input and forward vector (1 is forward, 0 is left or right and -1 is back movement)")]
		float forwardThreshhold = 0.65f;


		new Rigidbody rigidbody;

		// Functions
		private void Awake ()
		{
			rigidbody = GetComponent<Rigidbody>();
		}

		public void Move (Vector3 moveInput, float turning, bool slowWalk, bool sprint)
		{
			var turnQuaternion = Quaternion.Euler(0, turning * Time.deltaTime, 0);
			var moveDirection = transform.TransformDirection(moveInput);

			var normalizedInput = moveInput.normalized;

			bool isMovingForward = Vector3.Dot(normalizedInput, Vector3.forward) > forwardThreshhold;

			float calculatedSpeed = speed;
			if (!isMovingForward) {
				calculatedSpeed *= nonForwardSpeedMultiplier;
			}
			if (slowWalk) {
				calculatedSpeed *= slowWalkMultiplier;
			} else if (sprint && isMovingForward) {
				calculatedSpeed *= sprintMultiplier;
			}



			rigidbody.MovePosition(transform.position + (moveDirection * (Time.deltaTime * calculatedSpeed)));
			rigidbody.MoveRotation(transform.rotation * turnQuaternion);
		}
	}
}