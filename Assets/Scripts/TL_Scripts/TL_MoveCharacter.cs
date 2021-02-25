using UnityEngine;

public class TL_MoveCharacter : MonoBehaviour
{
    public float Speed;
    private float RotationSpeed = 0.15f;
    private Rigidbody CharacterRigidbody;


    void Start()
    {
        CharacterRigidbody = GetComponent<Rigidbody>();
    }

    void MoveCharacter()
    {
        //Store the axis inputs into float variables
        float xAxisInput = Input.GetAxisRaw("Horizontal");
        float zAxisInput = Input.GetAxisRaw("Vertical");

        //Normalize the player movement
        Vector3 PlayerMovement = new Vector3(xAxisInput, 0f, zAxisInput).normalized;

        //If the player moves the character
        if (xAxisInput > 0 || xAxisInput < 0 || zAxisInput > 0 || zAxisInput < 0)
        {
            //Make the character face towards the direction they are moving in
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(PlayerMovement), RotationSpeed);
        }

        //Move the character's rigidbody with move position
        CharacterRigidbody.MovePosition(transform.localPosition + (PlayerMovement * Speed * Time.fixedDeltaTime));
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }
    
}
