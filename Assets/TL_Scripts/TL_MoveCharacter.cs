using UnityEngine;

public class TL_MoveCharacter : MonoBehaviour
{
    public float Speed;
    private Rigidbody CharacterRigidbody;


    void Start()
    {
        CharacterRigidbody = GetComponent<Rigidbody>();
    }

    void MoveCharacter()
    {
        //Store the axis inputs into float variables
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        //Normalize the player movement
        Vector3 PlayerMovement = new Vector3(xInput, 0f, zInput).normalized;

        //Move the character's rigidbody with move position
        CharacterRigidbody.MovePosition(transform.localPosition + (PlayerMovement * Speed * Time.fixedDeltaTime));
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }
    
}
