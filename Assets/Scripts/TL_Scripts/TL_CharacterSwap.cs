using UnityEngine;

public class TL_CharacterSwap : MonoBehaviour
{
    public GameObject MaleHair;
    public GameObject FemaleHair;
    public Material MaleCharacterMaterial;
    public Material FemaleCharacterMaterial;
    public SkinnedMeshRenderer CharacterRenderer;
    private bool CharacterToggle;


    //Swapping the materials for the characters
    void SwapMaterial()
    {
        //If the tab key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Toggle the boolean
            CharacterToggle = !CharacterToggle;

            //If the toggle is true
            if (CharacterToggle)
            {
                //Set the male hair active and deactivate the female hair
                MaleHair.SetActive(true);
                FemaleHair.SetActive(false);

                //Change to the male character material from the skinned mesh renderer
                CharacterRenderer.material = MaleCharacterMaterial;
            }
            else      //If the toggle is false
            {
                //Set the male hair inactive and activate the female hair
                MaleHair.SetActive(false);
                FemaleHair.SetActive(true);

                //Change to the female character material from the skinned mesh renderer
                CharacterRenderer.material = FemaleCharacterMaterial;
            }
        }
    }

    void Update()
    {
        SwapMaterial();
    }

}
