using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	public class CursorPingLocation : MonoBehaviour 
	{
		// Variables
		[SerializeField] GameObject prefab;
		[SerializeField] LayerMask mask;


		// Functions
		private void Update ()
		{
			if (Input.GetMouseButtonDown(0)) {
				RaycastHit hit;
				if(Physics.Raycast(transform.position, transform.forward, out hit, 1000, mask)) {
					Instantiate(prefab, hit.point, Quaternion.identity);
				}
			}
		}
	}
}