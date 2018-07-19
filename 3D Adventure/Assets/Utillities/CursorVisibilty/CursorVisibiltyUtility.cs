using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	[CreateAssetMenu(menuName = "Utils/CursorVisibilty")]
	public class CursorVisibiltyUtility : ScriptableObject 
	{
		// Functions
		public void SetCursorVisibilty (bool visibility)
		{
			Cursor.visible = visibility;
		}
	}
}