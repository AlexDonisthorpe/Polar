using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    private int _levelToLoad;

    public void LoadLevel(int levelToLoad)
    {
        _levelToLoad = levelToLoad;
        GetComponent<Animator>().SetTrigger("FadeOut");
    }

    // bahaha omg.
    public void ActuallyLoadLevel()
    {
        SceneManager.LoadScene(_levelToLoad);
    }

}
