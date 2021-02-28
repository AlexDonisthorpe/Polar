using UnityEngine;

public class TL_SwapAbilities : MonoBehaviour
{
    public TL_DashCharacter DashScript;
    public TL_GrabObjects GrabObjectScript;
    public TL_ThrowObjects ThrowObjectScript;
    public bool AbilityToggle;


    //Toggle the abilities to swap with the characters
    void ToggleAbilities()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            AbilityToggle = !AbilityToggle;
            GrabObjectScript.enabled = AbilityToggle;
            ThrowObjectScript.enabled = AbilityToggle;

            if (AbilityToggle)
            {
                AkSoundEngine.SetSwitch("Dash", "Girl", gameObject);
                 AkSoundEngine.SetSwitch("MUSIC", "GIRL", gameObject);
                 AkSoundEngine.SetSwitch("Jump", "Girl", gameObject);
            } else
            {
                AkSoundEngine.SetSwitch("Dash", "Guy", gameObject);
                 AkSoundEngine.SetSwitch("MUSIC", "GUY", gameObject);
                 AkSoundEngine.SetSwitch("Jump", "Guy", gameObject);
            }
            
          
        }
    }

    void Update()
    {
        ToggleAbilities();
    }
}
