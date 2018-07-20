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

		bool jump;


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

			jump = Input.GetButtonDown("Jump");
		}

		private void FixedUpdate ()
		{
			var moveInput = new Vector3(strafeInput, 0, forwardInput);
			if(moveInput.sqrMagnitude > 1) {
				moveInput.Normalize();
			}

			movementController.Move(moveInput, slowWalk, sprint);
			movementController.Rotate(turnInput * mouseXSensivity);

			if (jump) {
				movementController.Jump();
				jump = false;
			}

			camController.RotateY(camTurnInput * mouseYSensivity);
		}
	}
}