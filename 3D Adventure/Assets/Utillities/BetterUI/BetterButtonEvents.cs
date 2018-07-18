using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Wokarol {
	[AddComponentMenu("UI/BetterButtonEvents")]
	public class BetterButtonEvents : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {

		[SerializeField] UnityEvent OnDown;
		[SerializeField] UnityEvent OnUp;
		[SerializeField] UnityEvent OnExit;
		[SerializeField] UnityEvent OnEnter;

		public void OnPointerDown (PointerEventData eventData) {
			OnDown.Invoke();
		}

		public void OnPointerUp (PointerEventData eventData) {
			OnUp.Invoke();
		}

		public void OnPointerExit (PointerEventData eventData)
		{
			OnExit.Invoke();
		}

		public void OnPointerEnter (PointerEventData eventData)
		{
			OnEnter.Invoke();
		}

	}
}