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
        GameObject myBullet = collision.gameObject;
        //myBullet.GetComponent<Rigidbody>().enabled = false;
        Bullet bulletID = myBullet.GetComponent<Bullet>(); 
        byte bID = bulletID.bulletID;


        if (collision.gameObject.layer == LayerMask.NameToLayer("Target"))
        {

            
            //int Rand = UnityEngine.Random.Range(maxhp - 2, maxhp + 3);
            //Debug.Log("Target HP: " + Rand);
            damage++;
           // Debug.Log("Dmg counter: " + damage);
            


            if (Utilidades.selectedProcedure == "Resistencia" && Utilidades.startRich == true)
            {
                Utilidades.LogEvent(Utilidades.currentPhase + ",2");
                if (Utilidades.currentPhase == 0 || Utilidades.currentPhase == 2)
                {
                    Utilidades.hitRico++;
                }
                else if (Utilidades.currentPhase == 1 || Utilidades.currentPhase == 3)
                {
                    Utilidades.hitPobre++;
                }

            }
            else if (Utilidades.selectedProcedure == "Resistencia" && Utilidades.startRich == false)
            {
                Utilidades.LogEvent(Utilidades.currentPhase + ",2");
                if (Utilidades.currentPhase == 0 || Utilidades.currentPhase == 2)
                {
                    Utilidades.hitPobre++;
                }
                else if (Utilidades.currentPhase == 1 || Utilidades.currentPhase == 3)
                {
                    Utilidades.hitRico++;
                }
            }
            else if (Utilidades.selectedProcedure == "Renovación" || Utilidades.selectedProcedure == "Restablecimiento")
            {
                Utilidades.hit++;
                Utilidades.LogEvent(Utilidades.currentPhase + ",2");
            }
            else if (Utilidades.selectedProcedure == "Resurgimiento" && bID == 1)
            {
                Utilidades.hitRO++;
                Utilidades.LogEvent(Utilidades.currentPhase + ",2,1");
            }
            else if (Utilidades.selectedProcedure == "Resurgimiento" && bID == 2)
            {
                Utilidades.hitRA++;
                Utilidades.LogEvent(Utilidades.currentPhase + ",2,2");
            }
           


                //if (damage >= hpget.TargetHP)
                if (hpget.isKillable == true)
                {
                             
                     

                         if (Utilidades.selectedProcedure == "Resistencia" && Utilidades.startRich == true)
                         {
                            if (Utilidades.currentPhase == 0 )
                            {
                               Utilidades.refsRico++;
                               Reinforce();
                               Utilidades.LogEvent(Utilidades.currentPhase + ",3");
                            }
                            else if (Utilidades.currentPhase == 1 )
                            {
                               Utilidades.refsPobre++;
                               Reinforce();
                               Utilidades.LogEvent(Utilidades.currentPhase + ",3");
                            }

                         }
                         else if  (Utilidades.selectedProcedure == "Resistencia" && Utilidades.startRich == false)
                         {
                              if (Utilidades.currentPhase == 1)
                              {
                                 Utilidades.refsRico++;
                                 Reinforce();
                                 Utilidades.LogEvent(Utilidades.currentPhase + ",3");
                              }
                              else if (Utilidades.currentPhase == 0)
                              {
                                 Utilidades.refsPobre++;
                                 Reinforce();
                                 Utilidades.LogEvent(Utilidades.currentPhase + ",3");
                              }
                         }
                         else if (Utilidades.selectedProcedure == "Renovación" || Utilidades.selectedProcedure == "Restablecimiento")
                         {
                              if (Utilidades.currentPhase == 1)
                              {
                                 Utilidades.refs++;
                                 Reinforce();
                                 Utilidades.LogEvent(Utilidades.currentPhase + ",3");
                              }
                         }
                         else if (Utilidades.selectedProcedure == "Resurgimiento" && bID == 1)
                         {
                             if (Utilidades.currentPhase == 1)
                             {
                                 Utilidades.refsRO++;
                                 Reinforce();
                                 Utilidades.LogEvent(Utilidades.currentPhase + ",3,1");
                             }
                         }
                         else if (Utilidades.selectedProcedure == "Resurgimiento" && bID == 2)
                         {
                             if (Utilidades.currentPhase == 2)
                             {
                                 Utilidades.refsRA++;
                                 Reinforce();
                                 Utilidades.LogEvent(Utilidades.currentPhase + ",3,2");
                             }
                         }
                         else if (Utilidades.selectedProcedure == "Restablecimiento" || Utilidades.selectedProcedure == "Restablecimiento")
                         {
                              if (Utilidades.currentPhase == 1)
                              {
                                   Utilidades.refs++;
                                   Reinforce();
                                   Utilidades.LogEvent(Utilidades.currentPhase + ",3");
                              }
                         }
                }
        }

    }
    

    public void Reinforce()
    {
        if (Utilidades.responseCost == true)
        {
            Utilidades.points += 100;
        }
        else
        {
            Utilidades.points += 1;
        }
        GameObject newObject = Instantiate(m_ProjectilePrefab, m_StartPoint.position, m_StartPoint.rotation, null);
        
        if (newObject.TryGetComponent(out Rigidbody rigidBody))
            ApplyForce(rigidBody);
       
        DestruirObjeto(gameObject);
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

    void ApplyForce(Rigidbody rigidBody)
    {
        Vector3 force = m_StartPoint.forward * m_LaunchSpeed;
        rigidBody.AddForce(force);
    }



}