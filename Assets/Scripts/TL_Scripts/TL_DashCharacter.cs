using System.Collections;
using UnityEngine;

public class TL_DashCharacter : MonoBehaviour
{
    public float ShoulderTackleDamage;
    public float DashForce;
    private float DashCooldown = 0.15f;
    public int NumberOfDashes = 1;
    private int DashLayer = 3;
    private int ShoulderTackleLayer = 6;
    private bool IsDashButtonPressed;
    private string TriggerName;
    private Animator CharacterAnimator;
    private Rigidbody CharacterRigidbody;
    private TL_JumpCharacter JumpingScript;
    private TL_SwapAbilities SwapAbilitiesScript;


    void Start()
    {
        JumpingScript = GetComponent<TL_JumpCharacter>();
        CharacterAnimator = GetComponent<Animator>();
        CharacterRigidbody = GetComponent<Rigidbody>();
        SwapAbilitiesScript = GetComponent<TL_SwapAbilities>();
    }

    //Creates a burst of speed for the character and adds a cooldown inbetween dashes
    IEnumerator Dash()
    {
        //If the dash button is press and the number of dashes is more than 0
        if (IsDashButtonPressed && NumberOfDashes > 0)
        {
            //Set the trigger to true
            CharacterAnimator.SetBool(TriggerName, true);

            //Add a burst of forward speed to the character
            CharacterRigidbody.AddForce(transform.forward * DashForce, ForceMode.Impulse);

            //Change the player's layer into Dash
            gameObject.layer = DashLayer;

            //Wait for a few seconds
            yield return new WaitForSeconds(DashCooldown);

            //If the character is not touching the ground while airborne
            if (!JumpingScript.IsCharacterTouchingTheGround())
            {
                //Reduce the number of dashes to 0
                NumberOfDashes = 0;
            }

            //Revert the player's layer into default
            gameObject.layer = 9;

            //Reset the character's velocity
            CharacterRigidbody.velocity = Vector3.zero;

            //Set the bool to false
            IsDashButtonPressed = false;

            //Set the trigger to false
            CharacterAnimator.SetBool(TriggerName, false);
        }
    }

    //Updates the properties of the dash ability whenever the player swaps characters
    void UpdateDashProperties()
    {
        //If the toggle is true
        if (SwapAbilitiesScript.AbilityToggle)
        {
            //Set the properties of the shoulder tackle
            TriggerName = "IsShoulderTackling";
            DashForce = 5f;
            DashLayer = ShoulderTackleLayer;
            ShoulderTackleDamage = 5f;
        }
        else
        {
            //Set the properties of the dash
            TriggerName = "IsDashing";
            DashForce = 10f;
            DashLayer = 3;
            ShoulderTackleDamage = 0f;
        }
    }

    //Pressing the dash button will trigger the condition to make the character dash
    public void DashButton()
    {
        //If the dash button is pressed then set it to a bool
        if (Input.GetKeyDown(KeyCode.LeftShift) && !IsDashButtonPressed)
        {
            UpdateDashProperties();
            IsDashButtonPressed = true;
        }
    }

    void UpdateNumberOfDashes()
    {
        //If the character is touching the ground
        if (JumpingScript.IsCharacterTouchingTheGround())
        {
            //Set number of dashes to 1
            NumberOfDashes = 1;
        }
    }

    void Update()
    {
        UpdateNumberOfDashes();
        DashButton();
    }

    void FixedUpdate()
    {
        StartCoroutine(Dash());
    }

}
