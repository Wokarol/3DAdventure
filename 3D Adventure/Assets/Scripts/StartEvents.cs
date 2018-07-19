using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol
{
	public class StartEvents : MonoBehaviour 
	{
		// Variables
		[SerializeField] UnityEvent onStart;

		// Functions
		private void Start ()
		{
			onStart.Invoke();
		}
	}
}