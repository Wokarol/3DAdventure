using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	public class RotateOnPress : MonoBehaviour, IInteractible
	{
		// Variables
		[SerializeField] float anglePerPress = 90;
		[SerializeField] Vector3 rotateDirection = new Vector3(1,0,0);
		[SerializeField] float rotationTime = 1f;

		[SerializeField][HideInInspector] float speed = 0;

		Quaternion targetAngle;

		// Functions
		public string InteractionText {
			get {
				return "Rotate";
			}
		}

		public float InteractionDistanceMultiplier {
			get {
				return 1;
			}
		}

		private void Start ()
		{
			targetAngle = transform.rotation;
		}

		private void Update ()
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, targetAngle, speed * Time.deltaTime);
		}

		public void Interact ()
		{
			Debug.Log(":OnScreen:Touched me");
			targetAngle *= Quaternion.AngleAxis(anglePerPress, rotateDirection);
		}

		private void OnDrawGizmosSelected ()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawRay(transform.position, rotateDirection.normalized * 2);
		}

		private void OnValidate ()
		{
			speed = anglePerPress / rotationTime;
		}
	}
}