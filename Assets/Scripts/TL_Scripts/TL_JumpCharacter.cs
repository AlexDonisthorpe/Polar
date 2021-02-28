using UnityEngine;

public class TL_JumpCharacter : MonoBehaviour
{
    public float JumpHeight;
    private float DistanceToGround;
    private Collider CharacterCollider;
    private Rigidbody CharacterRigidbody;
    private Animator CharacterAnimator;


    void Start()
    {
        //Obtain the collider and rigidbody
        CharacterCollider = GetComponent<Collider>();
        CharacterRigidbody = GetComponent<Rigidbody>();

        //Obtain the extents of the collider
        DistanceToGround = CharacterCollider.bounds.extents.y;

        CharacterAnimator = GetComponent<Animator>();
    }

    void Jump()
    {
        Debug.Log(IsCharacterTouchingTheGround());

        //If the player presses the jmup button and if the character is touching the ground
        if (Input.GetKey(KeyCode.Space) && IsCharacterTouchingTheGround())
        {
            //Add force to the Y position
            CharacterRigidbody.velocity = Vector3.up * JumpHeight;

            // Swappy Addforce to .velocity to solve the apparently random jumpheight bug,
            // sorry! ~ Alex
        }

        if (CharacterRigidbody.velocity.y > 0)
        {
            //Set the trigger to true
            CharacterAnimator.SetBool("IsJumping", true);
        }
        else if (CharacterRigidbody.velocity.y < -1f)
        {
            //Set the trigger to false
            CharacterAnimator.SetBool("IsLanding", true);
        }
        else if (CharacterRigidbody.velocity.y == 0)
        {
            //Set the trigger to true
            CharacterAnimator.SetBool("IsJumping", false);

            //Set the trigger to false
            CharacterAnimator.SetBool("IsLanding", false);
        }

    }

    //Checks if the character is touching the ground or not
    public bool IsCharacterTouchingTheGround()
    {
        return Physics.Raycast(transform.position, -Vector3.up, DistanceToGround + 0.1f);
    }

    void FixedUpdate()
    {
        Jump();
    }

}
