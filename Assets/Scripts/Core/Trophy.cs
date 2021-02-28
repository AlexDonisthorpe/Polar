using UnityEngine;
using Polar.UI;

namespace Polar.Core
{
    public class Trophy : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            FindObjectOfType<LevelController>().LoadYouWinCanvas();
        }
    }
}