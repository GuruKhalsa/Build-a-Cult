using UnityEngine;

namespace AssemblyCSharp
{
	public class ControllerInput : MonoBehaviour
	{
		public KeyCode jumpButton = KeyCode.Space;
		public KeyCode attackButton = KeyCode.F;
		public KeyCode actionButton = KeyCode.G;

		public bool actionButtonDown ()
		{
			return Input.GetKeyDown (actionButton);
		}

		public bool JumpDown ()
		{
			return Input.GetKeyDown (jumpButton);
		}

		public bool attacking ()
		{
			return Input.GetKey (attackButton);
		}

		public bool attackDown ()
		{
			return Input.GetKeyDown (attackButton);
		}

		public bool attackUp ()
		{
			return Input.GetKeyUp (attackButton);
		}

		public bool jumpUp ()
		{
			return Input.GetKeyUp (jumpButton);
		}

		public float movementX ()
		{
			return Input.GetAxis ("Horizontal");
		}

		public float movementY ()
		{
			return Input.GetAxis ("Vertical");
		}
	}
}
