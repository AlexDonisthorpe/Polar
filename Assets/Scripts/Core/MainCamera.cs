using UnityEngine;

namespace Polar.Core
{
    public class MainCamera : MonoBehaviour
    {
        private Transform _playerTransform;
        private Transform _cameraTransform;
        private Vector3 offset;

        private void Awake()
        {
            _cameraTransform = transform;
        }

        private void Start()
        {
            _playerTransform = FindObjectOfType<TL_MoveCharacter>().gameObject.transform;

            offset = _cameraTransform.position - _playerTransform.position;
        }

        private void FixedUpdate()
        {
            _cameraTransform.position = _playerTransform.position + offset;
        }

    }
}
