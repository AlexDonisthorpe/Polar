using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] PlatformRoute platformRoute;
    [SerializeField] float platformSpeed = 2f;
    [SerializeField] float _waypointLeeway = 2f;

    private Transform _transform;
    private int _waymarkCounter = 0;

    Waymark[] _waymarks;
    private Vector3 currentTarget;

    private void Awake()
    {
        _waymarks = platformRoute.GetComponentsInChildren<Waymark>();
        _transform = transform;

        if(_waymarks.Length == 0)
        {
            currentTarget = _transform.position;
        } else
        {
            currentTarget = _waymarks[_waymarkCounter].transform.position;
        }
    }

    private void Update()
    {
        CheckDistanceFromTarget();
    }

    private void CheckDistanceFromTarget()
    {
        float distFromTarget = Vector3.Distance(_transform.position, currentTarget);
        if (distFromTarget <= _waypointLeeway)
        {
            UpdateTargetWaymark();
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(_transform.position, currentTarget, platformSpeed * Time.deltaTime);
    }


    private void UpdateTargetWaymark()
    {
        _waymarkCounter++;
        
        if(_waymarkCounter == _waymarks.Length)
        {
            _waymarkCounter = 0;
        }

        currentTarget = _waymarks[_waymarkCounter].transform.position;
    }

}
