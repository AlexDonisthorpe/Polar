using UnityEngine;

namespace Polar.Obstacles
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] PlatformRoute platformRoute;
        [SerializeField] float platformSpeed = 2f;
        [SerializeField] float _waypointLeeway = 2f;

        private Transform _transform;
        private int _waymarkCounter = 0;
        private bool hasWaymarks = false;

        Waymark[] _waymarks;
        private Vector3 currentTarget;

        private void Awake()
        {
            _waymarks = platformRoute.GetComponentsInChildren<Waymark>();
            _transform = transform;

            //Setting the initial waymark (if there are any)
            if (_waymarks.Length == 0)
            {
                currentTarget = _transform.position;
            }
            else
            {
                currentTarget = _waymarks[_waymarkCounter].transform.position;
                hasWaymarks = true;
            }
        }

        private void Update()
        {
            if(hasWaymarks)
            {
                CheckDistanceFromTarget();
            }
        }

        private void FixedUpdate()
        {
            if(hasWaymarks)
            {
                transform.position = Vector3.Lerp(_transform.position, currentTarget, platformSpeed * Time.deltaTime);
            }
        }

        private void UpdateTargetWaymark()
        {
            _waymarkCounter++;

            if (_waymarkCounter == _waymarks.Length)
            {
                _waymarkCounter = 0;
            }

            currentTarget = _waymarks[_waymarkCounter].transform.position;
        }

        private void CheckDistanceFromTarget()
        {
            float distFromTarget = Vector3.Distance(_transform.position, currentTarget);
            if (distFromTarget <= _waypointLeeway)
            {
                UpdateTargetWaymark();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                other.transform.SetParent(transform, true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.transform.SetParent(null);
            }
        }

    }
}
