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
        if (Input.GetKey(KeyCode.Space) && IsCharacterTouchingTheGround())
        {
            //Add force to the Y position
            CharacterRigidbody.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);
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