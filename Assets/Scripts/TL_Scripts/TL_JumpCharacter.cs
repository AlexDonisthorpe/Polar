using System;
using UnityEngine;

public class TL_JumpCharacter : MonoBehaviour
{
    public float JumpHeight;
    private float DistanceToGround;
    private Collider CharacterCollider;
    private Rigidbody CharacterRigidbody;
    private Animator CharacterAnimator;

    [SerializeField] private int _jumpCounter = 0;
    [SerializeField] private float landingCheckDistance = 2f;

    private bool readyToJump;
    [SerializeField] private bool isJumping;


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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Nested ifs because c# isn't short-ciruiting my conditional with the function inside the first if?
            // ~ Alex

            if(IsCharacterTouchingTheGround())
            {
                if(_jumpCounter == 0)
                {
                    _jumpCounter++;
                    readyToJump = true;
                    CharacterAnimator.SetTrigger("IsJumping");
                    isJumping = true;

                }

            }
        }
    }

    //Checks if the character is touching the ground or not
    public bool IsCharacterTouchingTheGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, CharacterCollider.bounds.extents.y + 0.1f);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            _jumpCounter = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _jumpCounter++;
        }
    }

    void FixedUpdate()
    {
        if(readyToJump)
        {
            CharacterRigidbody.velocity = Vector3.zero;
            CharacterRigidbody.velocity = new Vector3(0f, JumpHeight, 0f);
            readyToJump = false;
        }
    }

    private void Update()
    {
        Jump();
        if (CharacterRigidbody.velocity.y < -3.5)
        {
            CharacterAnimator.SetTrigger("IsLanding");
        }

    }
}
