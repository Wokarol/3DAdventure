using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Wokarol
{
	[CustomPropertyDrawer(typeof(FloatMaxMin))]
	public class FloatMaxMinDrawer : PropertyDrawer 
	{
		// Variables
		Vector2 fieldSizeVector = new Vector2(0.5f, 1);


		// Functions
		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
		{
			label = EditorGUI.BeginProperty(position, label, property);
			position = EditorGUI.PrefixLabel(position, label);

			EditorGUI.BeginChangeCheck();

			var minValue = property.FindPropertyRelative("min");
			var maxValue = property.FindPropertyRelative("max");

			var minRect = new Rect(position.position, position.size * fieldSizeVector);
			var maxRect = new Rect(position.position + (position.size * new Vector2(0.5f, 0)), position.size * fieldSizeVector);

			var minLabelRect = new Rect(minRect.position, new Vector2(minRect.size.x * 0.2f, minRect.size.y));
			var minValueRect = new Rect(minRect.position + new Vector2(minRect.size.x * 0.2f, 0), new Vector2(minRect.size.x * 0.8f, minRect.size.y));

			var maxLabelRect = new Rect(maxRect.position, new Vector2(maxRect.size.x * 0.2f, maxRect.size.y));
			var maxValueRect = new Rect(maxRect.position + new Vector2(maxRect.size.x * 0.2f, 0), new Vector2(maxRect.size.x * 0.8f, maxRect.size.y));

			EditorGUI.PropertyField(minValueRect, minValue, GUIContent.none);
			EditorGUI.PropertyField(maxValueRect, maxValue, GUIContent.none);

			EditorGUI.LabelField(minLabelRect, "Min");
			EditorGUI.LabelField(maxLabelRect, "Max");

			if (EditorGUI.EndChangeCheck()){
				property.serializedObject.ApplyModifiedProperties();
			}

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label);
		}
	}
}