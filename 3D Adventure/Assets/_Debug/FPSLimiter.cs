﻿#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FPSLimiter : MonoBehaviour {
	[SerializeField] int maxFPS;


	private void Awake () {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = maxFPS;
	}
}
#endif
