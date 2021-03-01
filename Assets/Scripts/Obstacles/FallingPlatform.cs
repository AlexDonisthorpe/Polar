using System.Collections;
using UnityEngine;

namespace Polar.Obstacles
{
    [RequireComponent(typeof(Rigidbody))]
    public class FallingPlatform : MonoBehaviour
    {
        private Vector3 _startingPosition;
        private Rigidbody _rigidbody;
        private MeshRenderer _meshRenderer;
        private Quaternion _startingRotation;
        private Animator _animator;

        [SerializeField] float fallDelay = 2f;
        [SerializeField] float disappearDelay = 2f;
        [SerializeField] float respawnDelay = 4f;

        [Tooltip("Turning this on will cause the platform to drop as soon as the game starts.")]
        [SerializeField] bool isTesting = false;

        private void Awake()
        {
            //Caching...
            _startingPosition = transform.position;
            _rigidbody = GetComponent<Rigidbody>();
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
            _startingRotation = transform.rotation;
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            if(isTesting)
            {
                StartCoroutine("StartFalling");
            }
        }

        private IEnumerator StartFalling()
        {
            yield return new WaitForSeconds(fallDelay);
            _rigidbody.isKinematic = false;
            StartCoroutine(FadeAway());
        }

        private IEnumerator FadeAway()
        {
            yield return new WaitForSeconds(disappearDelay);
            _meshRenderer.enabled = false;

            StartCoroutine(StartRespawn());
        }

        private IEnumerator StartRespawn()
        {
            yield return new WaitForSeconds(respawnDelay);
            transform.position = _startingPosition;
            transform.rotation = _startingRotation;
            _meshRenderer.enabled = true;
            _rigidbody.isKinematic = true;
            _animator.SetTrigger("Respawned");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                AkSoundEngine.PostEvent("Fallingangel", gameObject);
                _animator.SetTrigger("Falling");
                StartCoroutine("StartFalling");
            }
        }

    }
}
