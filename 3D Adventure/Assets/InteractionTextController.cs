using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Wokarol
{
	[RequireComponent(typeof(TMP_Text))]
	public class InteractionTextController : MonoBehaviour
	{
		const string interactTag = "{interact}";

		// Variables
		TMP_Text textMesh;
		[TextArea(5, 20)]
		[SerializeField] string displayTextPattern;
		[TextArea(5, 20)]
		[SerializeField] string outOfRangeTextPattern;
		[SerializeField] BoolVariableReference canUse;
		[SerializeField] BoolVariableReference outOfRange;
		[SerializeField] InteractionDataVariableReference interactionData;

		private void Awake ()
		{
			textMesh = GetComponent<TMP_Text>();
		}

		// Functions
		private void Update ()
		{
			if (outOfRange.Value) {
				textMesh.text = ProcessText(outOfRangeTextPattern);
			} else if (canUse.Value) {
				textMesh.text = ProcessText(displayTextPattern);
			} else {
				textMesh.text = "";
			}
		}

		string ProcessText (string text)
		{
			while (text.Contains(interactTag)) {
				text = text.Replace(interactTag, "<b>" + interactionData.Value.InteractionText + "</b>");
			}

			return text;
		}

		private void OnValidate ()
		{
			if(textMesh == null) {
				textMesh = GetComponent<TMP_Text>();
			}
			if(textMesh != null) {
				textMesh.text = ProcessText(displayTextPattern);
			}
		}
	}
}