using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<LevelController>().LoadYouWinCanvas();       
    }
}
