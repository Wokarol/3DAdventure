using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	[RequireComponent(typeof(Rigidbody))]
	public class ThrowableItem : MonoBehaviour 
	{
		bool waitForThrow = false;

		// Variables
		float force = 200;
		float angularForce = 60;

		new Rigidbody rigidbody;
		// Functions

		private void Awake ()
		{
			rigidbody = GetComponent<Rigidbody>();
		}

		private void FixedUpdate ()
		{
			if (waitForThrow) {
				rigidbody.AddForce(force * transform.forward, ForceMode.Impulse);

				Vector3 torgueDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
				rigidbody.AddTorque(torgueDirection * angularForce, ForceMode.Impulse);

				waitForThrow = false;
			}
		}



		public void Throw (float _force, float _angularForce)
		{
			waitForThrow = true;

			force = _force;
			angularForce = _angularForce;
		}
	}
}