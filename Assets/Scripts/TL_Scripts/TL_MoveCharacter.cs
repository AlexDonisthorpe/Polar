using UnityEngine;

public class TL_MoveCharacter : MonoBehaviour
{
    public float Speed;
    private float RotationSpeed = 0.15f;
    private Animator _characterAnimator;
    private Rigidbody CharacterRigidbody;    
    private Vector3 PlayerMovement = Vector3.zero;
    private int xAxisHash;
    private int zAxisHash;

    void Awake()
    {
        _characterAnimator = GetComponent<Animator>();
        CharacterRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {

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

        xAxisHash = Animator.StringToHash("xAxis");
        zAxisHash = Animator.StringToHash("zAxis");
        

        //Normalize the player movement
        PlayerMovement = new Vector3(xAxisInput, 0f, zAxisInput).normalized;

        //If the player moves the character
        if (xAxisInput > 0 || xAxisInput < 0 || zAxisInput > 0 || zAxisInput < 0)
        {
            //Make the character face towards the direction they are moving in
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(PlayerMovement), RotationSpeed);
        }

        _characterAnimator.SetFloat(xAxisHash, xAxisInput);
        _characterAnimator.SetFloat(zAxisHash, zAxisInput);
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
