﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	public class JumpOnPress : MonoBehaviour, IInteractible
	{
		// Variables
		[SerializeField] float force = 250;
		[SerializeField] float torgueForce = 20;

		new Rigidbody rigidbody;

		public string InteractionText {
			get {
				return "Make me jump";
			}
		}

		public float InteractionDistanceMultiplier {
			get {
				return 1000;
			}
		}

		// Functions
		private void Awake ()
		{
			rigidbody = GetComponent<Rigidbody>();
		}

		public void Interact ()
		{
			rigidbody.AddForce(Vector3.up * (force * rigidbody.mass));

			Vector3 torgueDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
			Debug.DrawRay(transform.position, torgueDirection * 5f);

			rigidbody.AddTorque(torgueDirection * torgueForce);
		}
	}
}