using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	public class PlayerThrower : MonoBehaviour 
	{
		// Variables
		[SerializeField] ThrowableItem flaresPrefab;
		[SerializeField]float force = 500;
		[SerializeField]float angularForce = 150;

		// Functions
		private void Update ()
		{
			if (Input.GetMouseButtonDown(1)) {
				var _ob = Instantiate(flaresPrefab, transform.position, Quaternion.LookRotation(transform.forward, Vector3.up));
				_ob.Throw(force, angularForce);
			}
		}
	}
}