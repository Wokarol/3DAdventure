using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	public class JumpOnPress : MonoBehaviour, IInteractible
	{
		// Variables
		[SerializeField] float force;

		new Rigidbody rigidbody;
		// Functions
		private void Awake ()
		{
			rigidbody = GetComponent<Rigidbody>();
		}

		public void Interact ()
		{
			rigidbody.AddForce(Vector3.up * force);
		}
	}
}