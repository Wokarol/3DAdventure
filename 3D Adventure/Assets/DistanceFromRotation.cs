using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	public class DistanceFromRotation : MonoBehaviour 
	{
		// Variables
		[SerializeField] AnimationCurve rotToDistanceCurve;
		[SerializeField] Animator animator;
		[SerializeField] string blendTreeVariableName;
		[Space]
		[SerializeField] FloatVariableReference distanceData;


		int blendTreeVariableID;

		private void Start ()
		{
			Calculate();
		}

		// Functions
		private void Update ()
		{
			float rot = transform.rotation.eulerAngles.x;
			if (rot > 180) {
				rot = -(360 - rot);
			}

			float curveValue = distanceData.Value = rotToDistanceCurve.Evaluate(rot);

			animator.SetFloat(blendTreeVariableID, curveValue);
			//animator.SetFloat(blendTreeVariableName, curveValue);
		}

		void Calculate ()
		{
			blendTreeVariableID = Animator.StringToHash(blendTreeVariableName);
		}

		private void OnValidate ()
		{
			Calculate();
		}
	}
}