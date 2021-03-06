using UnityEngine;
using Polar.UI;

namespace Polar.Core
{
    public class Trophy : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            
            
            
            AkSoundEngine.PostEvent("Win", gameObject);
    
            FindObjectOfType<LevelController>().LoadYouWinCanvas();
        }
    }
}