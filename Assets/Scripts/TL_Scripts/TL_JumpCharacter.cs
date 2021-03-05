using UnityEngine;

public class TL_JumpCharacter : MonoBehaviour
{
    public float JumpHeight;
    private float DistanceToGround;
    private Collider CharacterCollider;
    private Rigidbody CharacterRigidbody;
    private Animator CharacterAnimator;

    [SerializeField] private int _jumpCounter = 0;
    private bool readyToJump;

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

                }

            }

            //Add force to the Y position

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

        var foo = Physics.CheckCapsule(CharacterCollider.bounds.center, new Vector3(CharacterCollider.bounds.center.x, CharacterCollider.bounds.max.y - 0.5f, CharacterCollider.bounds.center.z), CharacterCollider.bounds.max.x, 3);
        // Debug.Log(foo);
        return Physics.Raycast(transform.position, Vector3.down, CharacterCollider.bounds.extents.y + 0.1f);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
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
    }

}
