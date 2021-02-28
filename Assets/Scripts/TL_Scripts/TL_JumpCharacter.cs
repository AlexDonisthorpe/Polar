using UnityEngine;

public class TL_JumpCharacter : MonoBehaviour
{
    public float JumpHeight;
    private float DistanceToGround;
    private Collider CharacterCollider;
    private Rigidbody CharacterRigidbody;
    private Animator CharacterAnimator;

    //bodging this, with the inclusion of the new model, the raycast to ground isn't working
    private bool isTouchingTheGround = true;

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
        //If the player presses the jmup button and if the character is touching the ground
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingTheGround)
        {
            isTouchingTheGround = false;
            //Set the trigger to true
            CharacterAnimator.SetBool("IsJumping", true);

            //Add force to the Y position
            CharacterRigidbody.velocity = Vector3.up * JumpHeight;

            // Swappy Addforce to .velocity to solve the apparently random jumpheight bug,
            // sorry! ~ Alex
        }
        else
        {
            //Set the trigger to false
            CharacterAnimator.SetBool("IsJumping", false);
        }
    }

    //Checks if the character is touching the ground or not
    public bool IsCharacterTouchingTheGround()
    {
        return isTouchingTheGround;
    }

    void Update()
    {
        Jump();
    }

    private void OnCollisionStay(Collision collision)
    {
        isTouchingTheGround = true;
    }

}
