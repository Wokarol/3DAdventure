using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	public class CamController : MonoBehaviour 
	{
		// Variables
		[SerializeField] FloatMaxMin camVerticalLimit = new FloatMaxMin(-50, 50);


		// Functions
		public void RotateY (float rotateValue)
		{
			Vector3 rotation = transform.rotation.eulerAngles;
			if(rotation.x > 180) {
				rotation.x = -(360 - rotation.x);
			}

			rotation.x = Mathf.Clamp(rotation.x + rotateValue * Time.deltaTime, camVerticalLimit.min, camVerticalLimit.max);
			

			transform.rotation = Quaternion.Euler(rotation);
		}
	}
}