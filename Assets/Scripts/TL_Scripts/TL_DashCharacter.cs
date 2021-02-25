using System.Collections;
using UnityEngine;

public class TL_DashCharacter : MonoBehaviour
{
    public float ShoulderTackleDamage;
    public float DashForce;
    private float DashCooldown = 0.15f;
    private int DashLayer = 3;
    private int ShoulderTackleLayer = 6;
    private bool IsDashButtonPressed;
    private Rigidbody CharacterRigidbody;
    private TL_SwapAbilities SwapAbilitiesScript;


    void Start()
    {
        SwapAbilitiesScript = GetComponent<TL_SwapAbilities>();
        CharacterRigidbody = GetComponent<Rigidbody>();
    }

    //Creates a burst of speed for the character and adds a cooldown inbetween dashes
    IEnumerator Dash()
    {
        if (IsDashButtonPressed)
        {
            //Add a burst of forward speed to the character
            CharacterRigidbody.AddForce(transform.forward * DashForce, ForceMode.Impulse);

            //Change the player's layer into Dash
            gameObject.layer = DashLayer;

            //Wait for a few seconds
            yield return new WaitForSeconds(DashCooldown);

            //Revert the player's layer into default
            gameObject.layer = 0;

            //Reset the character's velocity
            CharacterRigidbody.velocity = Vector3.zero;

            //Set the bool to false
            IsDashButtonPressed = false;
        }
    }

    //Updates the properties of the dash ability whenever the player swaps characters
    void UpdateDashProperties()
    {
        //If the toggle is true
        if (SwapAbilitiesScript.AbilityToggle)
        {
            //Set the properties of the shoulder tackle
            DashForce = 5f;
            DashLayer = ShoulderTackleLayer;
            ShoulderTackleDamage = 5f;
        }
        else
        {
            //Set the properties of the dash
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

    void Update()
    {
        DashButton();
    }

    void FixedUpdate()
    {
        StartCoroutine(Dash());
    }

}
