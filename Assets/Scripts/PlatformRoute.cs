using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRoute : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        var _waymarks = GetComponentsInChildren<Waymark>();

        for (int i = 1; i < _waymarks.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_waymarks[i - 1].transform.position, _waymarks[i].transform.position);
        }
    }

}
