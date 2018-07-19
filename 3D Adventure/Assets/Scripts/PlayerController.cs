using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	[RequireComponent(typeof(MovementController))]
	public class PlayerController : MonoBehaviour 
	{
		// Variables
		[SerializeField] float mouseXSensivity = 3;
		[SerializeField] float mouseYSensivity = 3;
		[Space]
		[SerializeField] FirstPersonCamController camController;

		float forwardInput;
		float strafeInput;
		float turnInput;
		float camTurnInput;

		bool slowWalk;
		bool sprint;


		MovementController movementController;

		// Functions
		private void Awake ()
		{
			movementController = GetComponent<MovementController>();
		}

		private void Update ()
		{
			forwardInput = Input.GetAxisRaw("Vertical");
			strafeInput = Input.GetAxisRaw("Horizontal");

			turnInput = Input.GetAxisRaw("Look X");

			camTurnInput = Input.GetAxisRaw("Look Y");

			slowWalk = Input.GetButton("SlowWalk");
			sprint = Input.GetButton("Sprint");
		}

		private void FixedUpdate ()
		{
			var moveInput = new Vector3(strafeInput, 0, forwardInput);
			if(moveInput.sqrMagnitude > 1) {
				moveInput.Normalize();
			}

			movementController.Move(moveInput, turnInput * mouseXSensivity, slowWalk, sprint);

			camController.RotateY(camTurnInput * mouseYSensivity);
		}
	}
}