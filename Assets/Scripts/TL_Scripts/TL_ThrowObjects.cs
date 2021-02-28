using UnityEngine;

public class TL_ThrowObjects : MonoBehaviour
{    
    private TL_GrabObjects GrabObjectsScript;
    //private TL_AnimationFiniteStateMachine AnimationScript;


    void Start()
    {
        GrabObjectsScript = GetComponent<TL_GrabObjects>();

        //Obtain the animation FSM script
        //AnimationScript = GetComponent<TL_AnimationFiniteStateMachine>();
    }

    //Throws the picked up object
    void ThrowObject()
    {
        //If the throw button is pressed while the character is holding an object
        if (Input.GetKeyDown(KeyCode.T) && GrabObjectsScript.ReturnPickedUpObject() != null)
        {
            //Set the new state for the character
            //AnimationScript.SetNewState(TL_AnimationFiniteStateMachine.CharacterState.Throw);

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
        }
    }

    void Update()
    {
        ThrowObject();
    }

}
