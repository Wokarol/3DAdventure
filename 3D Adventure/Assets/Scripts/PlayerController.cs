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
		[SerializeField] CamController camController;

		float forwardInput;
		float strafeInput;
		float turnInput;
		float camTurnInput;

		bool slowWalk;
		bool sprint;

		bool jump;

		[Header("InputData")]
		[SerializeField] FloatVariableReference forwardInputData;
		[SerializeField] FloatVariableReference strafeInputData;
		[SerializeField] FloatVariableReference turnInputData;
		[SerializeField] FloatVariableReference camTurnInputData;

		[SerializeField] BoolVariableReference slowWalkData;
		[SerializeField] BoolVariableReference sprintData;

		[SerializeField] BoolVariableReference jumpData;


		MovementController movementController;

		// Functions
		private void Awake ()
		{
			movementController = GetComponent<MovementController>();
		}

		private void Update ()
		{
			forwardInputData.Value = forwardInput = Input.GetAxisRaw("Vertical");
			strafeInputData.Value = strafeInput = Input.GetAxisRaw("Horizontal");

			turnInputData.Value = turnInput = Input.GetAxisRaw("Look X");
			//turnInputData.Value = turnInput = 1;

			camTurnInputData.Value = camTurnInput = Input.GetAxisRaw("Look Y");

			slowWalkData.Value = slowWalk = Input.GetButton("SlowWalk");
			sprintData.Value = sprint = Input.GetButton("Sprint");

			//jump = Input.GetButtonDown("Jump");
			if (Input.GetButtonDown("Jump")) {
				jump = true;
			}
			jumpData.Value = Input.GetButton("Jump");
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
				Debug.Log(":OnScreen:Pressed jump!!!");
				jump = false;
			}

			camController.RotateY(camTurnInput * mouseYSensivity);
		}

		public void SetCamController (CamController _camController)
		{
			camController = _camController;
		}
	}
}