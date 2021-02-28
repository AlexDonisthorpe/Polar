using UnityEngine;

public class TL_CharacterSwap : MonoBehaviour
{
    public GameObject MaleHair;
    public GameObject FemaleHair;
    public Material MaleCharacterMaterial;
    public Material FemaleCharacterMaterial;
    public SkinnedMeshRenderer CharacterRenderer;
    private bool CharacterToggle;


    void SwapMaterial()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CharacterToggle = !CharacterToggle;
            if (CharacterToggle)
            {
                MaleHair.SetActive(true);
                FemaleHair.SetActive(false);
                CharacterRenderer.material = MaleCharacterMaterial;
            }
            else
            {
                MaleHair.SetActive(false);
                FemaleHair.SetActive(true);
                CharacterRenderer.material = FemaleCharacterMaterial;
            }
        }
    }

    void Update()
    {
        SwapMaterial();
    }

}
