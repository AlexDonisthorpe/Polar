using UnityEngine;

public class TL_GrabObjects : MonoBehaviour
{
	public bool GrabToggle;
	public GameObject PickedUpObject;
	//private TL_AnimationFiniteStateMachine AnimationScript;


    void Start()
    {
		//Obtain the animation FSM script
		//AnimationScript = GetComponent<TL_AnimationFiniteStateMachine>();
	}

    //Returns the child gameobject tagged as pickup
    public GameObject ReturnPickedUpObject()
	{
		if (transform.childCount > 0)
		{
			foreach (Transform Child in transform)
			{
				if (Child.tag == "Pickup")
				{
					PickedUpObject = Child.gameObject;
				}
			}
		}
		else
		{
			PickedUpObject = null;
		}
		return PickedUpObject;
	}

	//Resets the rotation and constraints of the rigidbody as well as un-parent the picked up object
	public void ResetObjetProperties(GameObject PickedUpObject)
	{
		//If the picked up object exists
		if (PickedUpObject != null)
		{
			//Sets rotations all to 0
			PickedUpObject.transform.rotation = new Quaternion(0, 0, 0, 0);

			//Freezes only the positions
			PickedUpObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

			//Sets the parent to null
			PickedUpObject.transform.SetParent(null);
		}
	}

	//Toggles the grabbing and dropping of an object
	void GrabObjectToggle()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			if (!GrabToggle)
			{
				PickUpObject();
			}
			else
			{
				DropObject();
			}
		}
	}

	//Pick up an object
	void PickUpObject()
	{
		//Assigns a Vector3 variable with a TransformDirection of Vector3.forward for the raycast
		Vector3 ForwardDirection = transform.TransformDirection(Vector3.forward * 2f);

		//Creates a ray in front of the PC
		Ray Raycast = new Ray(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), ForwardDirection);

		//Raycast hit variable for checking collision with the ray
		RaycastHit RayHitOutput;

		//If the ratcast hits an object that can be picked up
		if (Physics.Raycast(Raycast, out RayHitOutput, 2f))
		{
			//When the raycast hits the Pickup object
			if (RayHitOutput.transform.gameObject.CompareTag("Pickup"))
			{
				//Set the new state for the character
				//AnimationScript.SetNewState(TL_AnimationFiniteStateMachine.CharacterState.Grab);

				//Switch the toggle on
				GrabToggle = true;

				//Set the picked up object as the collided raycast object
				PickedUpObject = RayHitOutput.transform.gameObject;

				//Adds the object touched by the raycast to the parent transform
				RayHitOutput.transform.SetParent(transform);

				//Freezes all positions and rotations
				RayHitOutput.rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;

				//Sets local position
				RayHitOutput.transform.localPosition = new Vector3(0f, 1.7f, 0f);

				//Sets local rotation
				RayHitOutput.transform.localRotation = new Quaternion(0, 0, 0, 0);
			}
		}
	}

	//Drop the object in front of the player
	void DropObject()
	{
		//If the player still has the picked up object
		if (GrabToggle && ReturnPickedUpObject() != null)
		{
			//Drop the object in front of the character
			ReturnPickedUpObject().transform.position += transform.forward;

			//Sets rotations all to 0
			ReturnPickedUpObject().transform.rotation = new Quaternion(0, 0, 0, 0);

			//Freezes only the positions
			ReturnPickedUpObject().GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

			//Sets the parent to null
			ReturnPickedUpObject().transform.SetParent(null);

			//Update the picked up object variable
			ReturnPickedUpObject();

			//Switch the toggle off
			GrabToggle = false;
		}		
	}

	void Update()
    {
		GrabObjectToggle();
	}

}
