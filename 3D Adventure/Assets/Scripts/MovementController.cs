using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	[RequireComponent(typeof(Rigidbody))]
	public class MovementController : MonoBehaviour
	{

		const float groundCheckRadius = 0.3f;

		// Variables
		public float speed = 4;
		public float nonForwardSpeedMultiplier = 0.5f;
		public float slowWalkMultiplier = 0.5f;
		public float sprintMultiplier = 2f;
		[Space]
		public float jumpForce = 5;
		[Space]
		public LayerMask groundMask;
		public Vector3 groundCheckOffset;

		float forwardThreshhold = 0.65f;
		float yRotation;
		bool isGrounded;

		new Rigidbody rigidbody;

		// Functions
		private void Awake ()
		{
			rigidbody = GetComponent<Rigidbody>();
		}

		private void Start ()
		{
			yRotation = transform.rotation.eulerAngles.y;
		}

		private void Update ()
		{
			isGrounded = IsOnGround();
		}

		private bool IsOnGround ()
		{
			return (Physics.OverlapSphere(transform.TransformVector(groundCheckOffset) + transform.position, groundCheckRadius, groundMask).Length > 0);
		}

		public void Move (Vector3 moveInput, bool slowWalk, bool sprint)
		{
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

			var vel = rigidbody.velocity;
			vel.x = 0;
			vel.z = 0;
			rigidbody.velocity = vel;

			rigidbody.MovePosition(transform.position + (moveDirection * (Time.deltaTime * calculatedSpeed)));
		}
		public void Rotate (float value)
		{
			yRotation += Time.deltaTime * value;

			var rotation = transform.rotation.eulerAngles;
			rotation.y = yRotation;
			transform.rotation = Quaternion.Euler(rotation);
		}

		public void Jump ()
		{
			if (!isGrounded) {
				return;
			}
			rigidbody.AddForce(Vector3.up * jumpForce * rigidbody.mass, ForceMode.Impulse);
		}

		private void OnDrawGizmosSelected ()
		{
			Gizmos.DrawWireSphere(transform.TransformVector(groundCheckOffset) + transform.position, groundCheckRadius);
		}
	}
}