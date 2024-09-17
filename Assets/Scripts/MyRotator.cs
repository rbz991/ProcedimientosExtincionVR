using UnityEngine;

namespace Unity.VRTemplate
{
    
    /// <summary>
    /// Rotates this object at a user defined speed
    /// </summary>
    public class MyRotator : MonoBehaviour
    {
        private bool bln = false;
        [SerializeField, Tooltip("Angular velocity in degrees per second")]
        public Vector3 m_Velocity;

        void Update()
        {
            if (bln == false) {
                transform.Rotate(m_Velocity * Time.deltaTime);
            }
            else
            {
                Collider collider = GetComponent<Collider>();
                if (collider != null)
                {
                    collider.enabled = false;
                }
            }
           
        }
    

    void OnCollisionEnter(Collision collision)
    {
            bln = true;
    }

    }
}