using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Wokarol
{
	public class Test1 : MonoBehaviour 
	{
		// Variables

		// Functions
		[ContextMenu("Test")]
		public void Test ()
		{
			Debug.Log(EditorPrefs.GetString("gridColorX"));
			Debug.Log(EditorPrefs.GetString("gridColorY"));
			Debug.Log(EditorPrefs.GetString("gridColorZ"));
		}

		[ContextMenu("Test2")]
		public void Test2 ()
		{
			Debug.Log(Color.white.ToString());
		}
	}
}