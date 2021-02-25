using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polar.Obstacles
{
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

            Gizmos.DrawLine(_waymarks[_waymarks.Length - 1].transform.position, _waymarks[0].transform.position);
        }

    }
}
