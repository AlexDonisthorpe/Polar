using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    public int sceneId;
    public string levelDescription;
    public Sprite levelScreenshot;
}

