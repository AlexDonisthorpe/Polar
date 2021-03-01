using UnityEngine;

public class TL_ThrowObjects : MonoBehaviour
{
    private Animator CharacterAnimator;
    private TL_GrabObjects GrabObjectsScript;


    void Start()
    {
        CharacterAnimator = GetComponent<Animator>();
        GrabObjectsScript = GetComponent<TL_GrabObjects>();
    }

    //Throws the picked up object
    void ThrowObject()
    {
        //If the throw button is pressed while the character is holding an object
        if (Input.GetKeyDown(KeyCode.T) && GrabObjectsScript.ReturnPickedUpObject() != null)
        {
            //Set the trigger to false
            CharacterAnimator.SetBool("IsGrabbing", false);

            //Set the trigger to true
            CharacterAnimator.SetBool("IsThrowing", true);

            //Obtain the rigidbody from the picked up object
            Rigidbody ObjectRigidbody = GrabObjectsScript.ReturnPickedUpObject().GetComponent<Rigidbody>();

            //Add the force to throw the object
            ObjectRigidbody.AddForce(transform.forward * 1500f);

            //Reset the values of the picked up object
            GrabObjectsScript.ResetObjetProperties(GrabObjectsScript.ReturnPickedUpObject());

            //Switch the toggle off
            GrabObjectsScript.GrabToggle = false;

            //Update the dropped object
            GrabObjectsScript.ReturnPickedUpObject();

            //Set the trigger to false
            CharacterAnimator.SetBool("IsThrowing", false);
        }
    }

    void Update()
    {
        ThrowObject();
    }

}
