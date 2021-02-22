using UnityEngine;

public class TL_JumpCharacter : MonoBehaviour
{
    public float JumpHeight;
    private float DistanceToGround;
    private Collider CharacterCollider;
    private Rigidbody CharacterRigidbody;


    void Start()
    {
        //Obtain the collider and rigidbody
        CharacterCollider = GetComponent<Collider>();
        CharacterRigidbody = GetComponent<Rigidbody>();

        //Obtain the extents of the collider
        DistanceToGround = CharacterCollider.bounds.extents.y;
    }

    void Jump()
    {
        //If the player presses the jmup button and if the character is touching the ground
        if (Input.GetButton("Jump") && IsCharacterTouchingTheGround())
        {
            //Store the default X velocity
            float xAxis = CharacterRigidbody.velocity.x;

            //Create a vector2 variable to store the X axis and the jump height
            Vector2 JumpPosition = new Vector2(xAxis, JumpHeight);

            //Set the velocity with the new jump position
            CharacterRigidbody.velocity = JumpPosition;
        }
    }

    //Checks if the character is touching the ground or not
    bool IsCharacterTouchingTheGround()
    {
        return Physics.Raycast(transform.position, -Vector3.up, DistanceToGround);
    }

    void FixedUpdate()
    {
        Jump();
    }
}
