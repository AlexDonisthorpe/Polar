using System;
using UnityEngine;

public class TL_SwapAbilities : MonoBehaviour
{
    public TL_DashCharacter DashScript;
    public TL_GrabObjects GrabObjectScript;
    public TL_ThrowObjects ThrowObjectScript;
    public bool AbilityToggle;

    // ~ Alex's stuff ~
    // Ideally I'd put a script on the meshrenderer object to do all this,
    // But for now I want all the character swap stuff in one place.

    [SerializeField] private SkinnedMeshRenderer characterRenderer;
    [SerializeField] private Material blueMat;
    [SerializeField] private Material redMat;
    [SerializeField] private GameObject boyHair;
    [SerializeField] private GameObject girlHair;


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
                SwitchToGirl();

            } else
            {
                SwitchToBoy();

            }
        }
    }

    private void SwitchToGirl()
    {
        AkSoundEngine.SetSwitch("Dash", "Girl", gameObject);
        AkSoundEngine.SetSwitch("Jump", "Girl", gameObject);
        characterRenderer.material = redMat;
        boyHair.SetActive(false);
        girlHair.SetActive(true);
    }

    private void SwitchToBoy()
    {
        AkSoundEngine.SetSwitch("Dash", "Guy", gameObject);
        AkSoundEngine.SetSwitch("Jump", "Guy", gameObject);
        characterRenderer.material = blueMat;
        girlHair.SetActive(false);
        boyHair.SetActive(true);
    }

    void Update()
    {
        ToggleAbilities();
    }
}
