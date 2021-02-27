using UnityEngine;

public class TL_JumpCharacter : MonoBehaviour
{
    public float JumpHeight;
    private float DistanceToGround;
    private Collider CharacterCollider;
    private Rigidbody CharacterRigidbody;
    private TL_AnimationFiniteStateMachine AnimationScript;


    void Start()
    {
        //Obtain the collider and rigidbody
        CharacterCollider = GetComponent<Collider>();
        CharacterRigidbody = GetComponent<Rigidbody>();

        //Obtain the extents of the collider
        DistanceToGround = CharacterCollider.bounds.extents.y;

        //Obtain the animation FSM script
        AnimationScript = GetComponent<TL_AnimationFiniteStateMachine>();
    }

    void Jump()
    {
        //If the player presses the jmup button and if the character is touching the ground
        if (Input.GetKey(KeyCode.Space) && IsCharacterTouchingTheGround())
        {
            //Set the new state for the character
            AnimationScript.SetNewState(TL_AnimationFiniteStateMachine.CharacterState.Jump);

            //Add force to the Y position
            CharacterRigidbody.velocity = Vector3.up * JumpHeight;

            // Swappy Addforce to .velocity to solve the apparently random jumpheight bug,
            // sorry! ~ Alex
        }
    }

    //Checks if the character is touching the ground or not
    bool IsCharacterTouchingTheGround()
    {
        return Physics.Raycast(transform.position, -Vector3.up, DistanceToGround + 0.1f);
    }

    void FixedUpdate()
    {
        Jump();
    }

}
