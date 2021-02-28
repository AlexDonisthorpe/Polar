using UnityEngine;

public class TL_MoveCharacter : MonoBehaviour
{
    public float Speed;
    private float RotationSpeed = 0.15f;
    private Animator CharacterAnimator;
    private Rigidbody CharacterRigidbody;    
    private Vector3 PlayerMovement = Vector3.zero;
        

    void Awake()
    {
        CharacterAnimator = GetComponent<Animator>();
        CharacterRigidbody = GetComponent<Rigidbody>();
    }

    // Moving some movement code into update for use /during/ lateupdate.
    // ~ Alex
    private void Update()
    {
        SetupMovement();
    }

    private void SetupMovement()
    {
        //Store the axis inputs into float variables
        float xAxisInput = Input.GetAxisRaw("Horizontal");
        float zAxisInput = Input.GetAxisRaw("Vertical");

        //Normalize the player movement
        PlayerMovement = new Vector3(xAxisInput, 0f, zAxisInput).normalized;

        //If the player moves the character
        if (xAxisInput > 0 || xAxisInput < 0 || zAxisInput > 0 || zAxisInput < 0)
        {
            //Set the trigger to true
            CharacterAnimator.SetBool("IsRunning", true);

            //Make the character face towards the direction they are moving in
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(PlayerMovement), RotationSpeed);
        }
        else
        {
            //Set the trigger to false
            CharacterAnimator.SetBool("IsRunning", false);
        }
    }

    void MoveCharacter()
    {
        //Move the character's rigidbody with move position
        CharacterRigidbody.MovePosition(transform.localPosition + (PlayerMovement * Speed * Time.fixedDeltaTime));
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }
    
}
