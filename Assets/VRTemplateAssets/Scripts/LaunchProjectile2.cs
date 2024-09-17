using UnityEngine;

namespace Unity.VRTemplate
{
    /// <summary>
    /// Apply forward force to instantiated prefab
    /// </summary>
    public class LaunchProjectile2 : MonoBehaviour
    {
        public byte ID;
        [SerializeField]
        [Tooltip("The projectile that's created")]
        public GameObject m_ProjectilePrefab0 = null;
        public AudioClip audioSource0 = null;
        public GameObject m_ProjectilePrefab1 = null;
        public AudioClip audioSource1 = null;
        public GameObject m_ProjectilePrefab2 = null;
        public AudioClip audioSource2 = null;

        public GameObject m_ProjectilePrefabTO = null;
        public AudioClip audioSourceTO = null;

        [SerializeField]
        [Tooltip("The point that the project is created")]
        Transform m_StartPoint = null;

        [SerializeField]
        [Tooltip("The speed at which the projectile is launched")]
        float m_LaunchSpeed = 1.0f;
       
        public GameObject tmpGracias;
        

        public void Fire()
        {

            if (PhaseManager.points == 0)
            {
                Utilidades.LogEvent("null," + PhaseManager.currentPhase);
            }
            else
            {


                if (Utilidades.TimeOut == false) // ya tengo el id en este miosmo script, solo es decirle que si hay TO entonces por unos segundos no funcione
                {
                    PhaseManager.points--;
                    if (PhaseManager.currentPhase == 0)
                    {
                        GameObject newObject = Instantiate(m_ProjectilePrefab0, m_StartPoint.position, m_StartPoint.rotation, null);
                        if (newObject.TryGetComponent(out Rigidbody rigidBody))
                            ApplyForce(rigidBody);
                        PlaySound(audioSource0);
                    }
                    else if (PhaseManager.currentPhase == 1 || PhaseManager.currentPhase == 3 || PhaseManager.currentPhase == 5 || PhaseManager.currentPhase == 7)
                    {
                        PhaseManager.shootRico++;
                        Utilidades.LogEvent("shoot," + PhaseManager.currentPhase);
                        GameObject newObject = Instantiate(m_ProjectilePrefab1, m_StartPoint.position, m_StartPoint.rotation, null);
                        if (newObject.TryGetComponent(out Rigidbody rigidBody))
                            ApplyForce(rigidBody);
                        PlaySound(audioSource1);
                    }
                    else if (PhaseManager.currentPhase == 2 || PhaseManager.currentPhase == 4 || PhaseManager.currentPhase == 6 || PhaseManager.currentPhase == 8)
                    {
                        PhaseManager.shootPobre++;
                        Utilidades.LogEvent("shoot," + PhaseManager.currentPhase);
                        GameObject newObject = Instantiate(m_ProjectilePrefab2, m_StartPoint.position, m_StartPoint.rotation, null);
                        if (newObject.TryGetComponent(out Rigidbody rigidBody))
                            ApplyForce(rigidBody);
                        PlaySound(audioSource2);
                    }
                }
                else
                {
                    GameObject newObject = Instantiate(m_ProjectilePrefabTO, m_StartPoint.position, m_StartPoint.rotation, null);
                    if (newObject.TryGetComponent(out Rigidbody rigidBody))
                        ApplyForce(rigidBody);
                    PlaySound(audioSourceTO);
                }
                

              

            }
            
        }

      
        void ApplyForce(Rigidbody rigidBody)
        {
            Vector3 force = m_StartPoint.forward * m_LaunchSpeed;
            rigidBody.AddForce(force);
        }


        


   
        

       


        public void PlaySound(AudioClip myClip)
        {
            if (audioSource0 != null && audioSource0 != null && audioSource0 != null )
            {
                AudioSource.PlayClipAtPoint(myClip, transform.position);

            }
            else
            {
                Debug.LogWarning("No se encontró un AudioSource en este GameObject.");
            }
        }
    }


}

