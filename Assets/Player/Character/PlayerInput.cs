using UnityEngine;
using UnityEngine.Events;

namespace SnSMovement.Character
{
	[System.Serializable]
	public class InputAxisEvent : UnityEvent<float> { }

	public class PlayerInput : MonoBehaviour
	{

		public InputAxisEvent onHorizontalInputAxis = new InputAxisEvent ();
		public InputAxisEvent onVerticalInputAxis = new InputAxisEvent ();

		private void Update ()
		{
			onHorizontalInputAxis.Invoke (Input.GetAxisRaw("Horizontal"));
			onVerticalInputAxis.Invoke (Input.GetAxisRaw("Vertical"));
		}
	}
}