using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polar.Obstacles
{
    public class Waymark : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.2f);
        }
    }
}
