using UnityEngine;
using System.Collections;

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

            //HAY QUE AJUSTAR LAS ARMAS Y BALAS PARA RESURG


           
            if (Utilidades.responseCost == true) Utilidades.points--;

            if (Utilidades.canRespond == false)
            {
                Utilidades.TOresp++;
                Utilidades.LogEvent(Utilidades.currentPhase + ",4" + ID);
                GameObject newObject = Instantiate(m_ProjectilePrefabTO, m_StartPoint.position, m_StartPoint.rotation, null);
                if (newObject.TryGetComponent(out Rigidbody rigidBody))
                    ApplyForce(rigidBody);
                PlaySound(audioSourceTO);
            }
            else
            {


                if (Utilidades.hasStarted == false)
                {
                    GameObject newObject = Instantiate(m_ProjectilePrefab0, m_StartPoint.position, m_StartPoint.rotation, null);
                    if (newObject.TryGetComponent(out Rigidbody rigidBody))
                        ApplyForce(rigidBody);
                    PlaySound(audioSource0);
                }
                else
                {
                    if (Utilidades.selectedProcedure == "Resistencia" && Utilidades.startRich == true)
                    {
                        if (Utilidades.currentPhase == 0 || Utilidades.currentPhase == 2)
                        {
                            Utilidades.shootRico++;
                            Utilidades.LogEvent(Utilidades.currentPhase + ",1" );
                            GameObject newObject = Instantiate(m_ProjectilePrefab1, m_StartPoint.position, m_StartPoint.rotation, null);
                            if (newObject.TryGetComponent(out Rigidbody rigidBody))
                                ApplyForce(rigidBody);
                            PlaySound(audioSource1);
                        }
                        if (Utilidades.currentPhase == 1 || Utilidades.currentPhase == 3)
                        {
                            Utilidades.shootPobre++;
                            Utilidades.LogEvent(Utilidades.currentPhase  + ",1" );
                            GameObject newObject = Instantiate(m_ProjectilePrefab1, m_StartPoint.position, m_StartPoint.rotation, null);
                            if (newObject.TryGetComponent(out Rigidbody rigidBody))
                                ApplyForce(rigidBody);
                            PlaySound(audioSource1);
                        }
                    }
                    else if (Utilidades.selectedProcedure == "Resistencia" && Utilidades.startRich == false)
                    {
                        if (Utilidades.currentPhase == 1 || Utilidades.currentPhase == 3)
                        {
                            Utilidades.shootRico++;
                            Utilidades.LogEvent(Utilidades.currentPhase + ",1" );
                            GameObject newObject = Instantiate(m_ProjectilePrefab1, m_StartPoint.position, m_StartPoint.rotation, null);
                            if (newObject.TryGetComponent(out Rigidbody rigidBody))
                                ApplyForce(rigidBody);
                            PlaySound(audioSource1);
                        }
                        if (Utilidades.currentPhase == 0 || Utilidades.currentPhase == 2)
                        {
                            Utilidades.shootPobre++;
                            Utilidades.LogEvent(Utilidades.currentPhase + ",1" );
                            GameObject newObject = Instantiate(m_ProjectilePrefab1, m_StartPoint.position, m_StartPoint.rotation, null);
                            if (newObject.TryGetComponent(out Rigidbody rigidBody))
                                ApplyForce(rigidBody);
                            PlaySound(audioSource1);
                        }
                    }
                    else if (Utilidades.selectedProcedure == "Renovación" || Utilidades.selectedProcedure == "Restablecimiento")
                    {
                        Utilidades.shoot++;
                        Utilidades.LogEvent(Utilidades.currentPhase + ",1" );
                        GameObject newObject = Instantiate(m_ProjectilePrefab1, m_StartPoint.position, m_StartPoint.rotation, null);
                        if (newObject.TryGetComponent(out Rigidbody rigidBody))
                            ApplyForce(rigidBody);
                        PlaySound(audioSource1);
                    }
                    else if (Utilidades.selectedProcedure == "Resurgimiento" && ID == 1)
                    {
                        if (Utilidades.currentPhase == 2 && Utilidades.TimeOut == true)
                        {
                            StartCoroutine(TODuration(Utilidades.timeOutDuration));
                            Utilidades.TOresp++;
                            Utilidades.LogEvent(Utilidades.currentPhase + ",4" + ID);
                            GameObject newObject = Instantiate(m_ProjectilePrefabTO, m_StartPoint.position, m_StartPoint.rotation, null);
                            if (newObject.TryGetComponent(out Rigidbody rigidBody))
                            ApplyForce(rigidBody);
                            PlaySound(audioSourceTO);
                        }
                        else
                        {
                            Utilidades.shootRO++;
                            Utilidades.LogEvent(Utilidades.currentPhase + ",1," + ID);
                            GameObject newObject = Instantiate(m_ProjectilePrefab1, m_StartPoint.position, m_StartPoint.rotation, null);
                            if (newObject.TryGetComponent(out Rigidbody rigidBody))
                            ApplyForce(rigidBody);
                            PlaySound(audioSource1);
                        }
                        
                    }
                    else if (Utilidades.selectedProcedure == "Resurgimiento" && ID == 2)
                    {
                            if (Utilidades.currentPhase == 1 && Utilidades.TimeOut == true)
                            {
                                StartCoroutine(TODuration(Utilidades.timeOutDuration));
                                Utilidades.TOresp++;
                                Utilidades.LogEvent(Utilidades.currentPhase + ",4" + ID);
                                GameObject newObject = Instantiate(m_ProjectilePrefabTO, m_StartPoint.position, m_StartPoint.rotation, null);
                                if (newObject.TryGetComponent(out Rigidbody rigidBody))
                                ApplyForce(rigidBody);
                                PlaySound(audioSourceTO);
                            }
                            else
                            {
                               Utilidades.shootRA++;
                               Utilidades.LogEvent(Utilidades.currentPhase + ",1" + ID);
                               GameObject newObject = Instantiate(m_ProjectilePrefab2, m_StartPoint.position, m_StartPoint.rotation, null);
                               if (newObject.TryGetComponent(out Rigidbody rigidBody))
                               ApplyForce(rigidBody);
                               PlaySound(audioSource1);  
                            }
                    }

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

        IEnumerator TODuration(float secs)
        {
            Utilidades.canRespond = false;
            yield return new WaitForSeconds(secs);
            Utilidades.canRespond = true;


        }


    }


   


}

