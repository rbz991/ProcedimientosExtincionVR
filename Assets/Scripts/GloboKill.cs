using Unity.VRTemplate;
using UnityEngine;


public class DestroyOnCollision : MonoBehaviour
{
    private MoveAndBob hpget;
    public  int maxhp;
 
    private byte damage;
    public GameObject m_ProjectilePrefab = null;
    public  Transform m_StartPoint = null;
    public  float m_LaunchSpeed = 1.0f;

    private void Start()
    {
        hpget = GetComponent<MoveAndBob>();
    }

    void OnCollisionEnter(Collision collision)
       

    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Target"))
        {

            
            //int Rand = UnityEngine.Random.Range(maxhp - 2, maxhp + 3);
            //Debug.Log("Target HP: " + Rand);
            damage++;
           // Debug.Log("Dmg counter: " + damage);
            Utilidades.LogEvent("hit," + PhaseManager.currentPhase);

            if (PhaseManager.currentPhase == 1 || PhaseManager.currentPhase == 3 || PhaseManager.currentPhase == 5 || PhaseManager.currentPhase == 7)
            {
                PhaseManager.hitRico++;
            }
            else if (PhaseManager.currentPhase == 2 || PhaseManager.currentPhase == 4 || PhaseManager.currentPhase == 6 || PhaseManager.currentPhase == 8)
            {
                PhaseManager.hitPobre++;
            }


          
            //if (damage >= hpget.TargetHP)
            if (hpget.isKillable == true)
            {

                if (PhaseManager.currentPhase >= 1 && PhaseManager.currentPhase <= 8)
                {
                    // Your code here
               

                Reinforce();
                    PhaseManager.points += 100;
                    PhaseManager.refs ++;

                    if (PhaseManager.currentPhase == 1 || PhaseManager.currentPhase == 3 || PhaseManager.currentPhase == 5 || PhaseManager.currentPhase == 7 )
                    {
                        PhaseManager.refsRico++;
                    }
                    else if (PhaseManager.currentPhase == 2 || PhaseManager.currentPhase == 4 || PhaseManager.currentPhase == 6 || PhaseManager.currentPhase == 8 )
                    {
                        PhaseManager.refsPobre++;
                    }



                    Utilidades.LogEvent("kill," + PhaseManager.currentPhase);
                    DestruirObjeto(gameObject); // Destroys this object
                }
                
            


             }


        }



    }


    public void DestruirObjeto(GameObject objeto)
    {
        // Recuperar el spawnIndex del objeto
        SpawnedObject spawnedObject = objeto.GetComponent<SpawnedObject>();
        if (spawnedObject != null)
        {
            int spawnIndex = spawnedObject.spawnIndex;

            // Llamar al método estático LiberarPuntoDeSpawn de la clase Utilidades
            Utilidades.LiberarPuntoDeSpawn(spawnIndex);

            // Destruir el objeto
            Destroy(objeto);
        }
        else
        {
            Debug.LogWarning("El objeto no tiene un componente SpawnedObject.");
        }
    }



    public void Reinforce()
    {
        GameObject newObject = Instantiate(m_ProjectilePrefab, m_StartPoint.position, m_StartPoint.rotation, null);
        
        if (newObject.TryGetComponent(out Rigidbody rigidBody))
            ApplyForce(rigidBody);
    }


    void ApplyForce(Rigidbody rigidBody)
    {
        Vector3 force = m_StartPoint.forward * m_LaunchSpeed;
        rigidBody.AddForce(force);
    }



}