namespace Polar.Obstacles
{
    using UnityEngine;

    public class CrashCrate : MonoBehaviour
    {
        [Header("Whole Create")]
        public MeshRenderer wholeCrate;
        public BoxCollider boxCollider;

        [Header("Fractured Create")]
        public GameObject fracturedCrate;

        [Header("Test")]
        [SerializeField] bool testing;

        private bool hasExploded = false;

        private void Update()
        {
            if(testing && !hasExploded)
            {
                BlowUp(500);
                hasExploded = true;
            }
        }

        [ContextMenu("Test")]
        public void BlowUp(float explosionForce)
        {
            wholeCrate.enabled = false;
            fracturedCrate.SetActive(true);
            Boom(explosionForce);
        }

        private void Boom(float explosionForce)
        {
            Rigidbody[] allRigidBodies = fracturedCrate.GetComponentsInChildren<Rigidbody>();
            if (allRigidBodies.Length > 0)
            {
                foreach (var body in allRigidBodies)
                {
                    body.AddExplosionForce(explosionForce, transform.position, 1);
                }
            }
        }
    }
}