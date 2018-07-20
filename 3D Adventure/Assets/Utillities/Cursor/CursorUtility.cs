using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	[CreateAssetMenu(menuName = "Utils/CursorVisibilty")]
	public class CursorUtility : ScriptableObject 
	{
		// Functions
		public void SetCursorVisibilty (bool visibility)
		{
			Cursor.visible = visibility;
		}

		public void SetCursorLockState (bool state)
		{
			Cursor.lockState = (state)?CursorLockMode.Locked:CursorLockMode.None;
		}
	}
}