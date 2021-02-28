using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateButton : MonoBehaviour
{
    [SerializeField] GameObject _gameObjectToActivate;
    [SerializeField] Material _activatedMaterial;
    [SerializeField] GameObject _button;

    private void OnCollisionEnter(Collision collision)
    {
        _gameObjectToActivate.SetActive(true);
        _button.GetComponent<MeshRenderer>().material = _activatedMaterial;
    }

}
