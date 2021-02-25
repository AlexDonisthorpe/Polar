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
        }
    }

    void Update()
    {
        ToggleAbilities();
    }
}
