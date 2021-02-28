using UnityEngine;

public class TL_GrabObjects : MonoBehaviour
{
	public bool GrabToggle;
	public GameObject PickedUpObject;
	private Animator CharacterAnimator;
    [SerializeField] private GameObject storedObject = null;


	void Start()
    {
		CharacterAnimator = GetComponent<Animator>();
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
<<<<<<< HEAD
        //When the raycast hits the Pickup object
        if (storedObject != null)
        {
            //Set the trigger to true
            CharacterAnimator.SetBool("IsGrabbing", true);

            //Switch the toggle on
            GrabToggle = true;
=======
		//Assigns a Vector3 variable with a TransformDirection of Vector3.forward for the raycast
		Vector3 ForwardDirection = transform.TransformDirection(Vector3.forward);

		//Creates a ray in front of the PC
		Ray Raycast = new Ray(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), ForwardDirection);
>>>>>>> a84f3b75d8e5eb19583afa482c98edab7f8a02ea

            //Set the picked up object as the collided raycast object
            PickedUpObject = storedObject;

            //Adds the object touched by the raycast to the parent transform
            PickedUpObject.transform.SetParent(transform);

            //Freezes all positions and rotations
            PickedUpObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;

            //Sets local position
            PickedUpObject.transform.localPosition = new Vector3(0f, 1.7f, 0f);

<<<<<<< HEAD
            //Sets local rotation
            PickedUpObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
    }
=======
				//Freezes all positions and rotations
				RayHitOutput.rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;

				//Sets local position
				RayHitOutput.transform.localPosition = new Vector3(0f, 2.5f, 0f);

				//Sets local rotation
				RayHitOutput.transform.localRotation = new Quaternion(0, 0, 0, 0);
			}
		}
	}
>>>>>>> a84f3b75d8e5eb19583afa482c98edab7f8a02ea

	//Drop the object in front of the player
	void DropObject()
	{
		//If the player still has the picked up object
		if (GrabToggle && ReturnPickedUpObject() != null)
		{
			//Set the trigger to false
			CharacterAnimator.SetBool("IsGrabbing", false);

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            storedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            storedObject = null;
        }
    }

}
