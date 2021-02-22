using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("play", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
