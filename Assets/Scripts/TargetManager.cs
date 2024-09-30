using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class TargetManager : MonoBehaviour
{


    private static List<int> SpawnPointsIndex = new List<int>();

    private List<GameObject> currentTargets = new List<GameObject>();
    
    public GameObject targetPrefab; // The prefab for the target to spawn
    public GameObject targetPrefab2; // The prefab for the target to spawn
    public GameObject targetPrefab3; // The prefab for the target to spawn
    public Transform[] spawnPoints; // Array of spawn points
    private GameObject currentTarget; // Currently active target
    //private int lastSpawnIndex = -1; // To store the last used spawn index
                                     // public float moveDistance = 5f; // Distance each target will move
                                     // public float moveSpeed = 1f; // Speed of the movement
                                     // public Vector3 moveDirection = Vector3.forward; // Direction of the movement

    void Update()
    {

        if (Utilidades.hasStarted == true)
        { 
            currentTargets.RemoveAll(target => target == null);
        // Check if there are fewer targets than the allowed simultaneous targets
        if (currentTargets.Count < Utilidades.GlobosSimultaneos)
        {
            SpawnTarget();
        }
    }
    }

    void SpawnTarget()
    {
        int spawnIndex;
        System.Random Rand = new System.Random();
        int p;

        if (SpawnPointsIndex.Count == 0)
        {
            // Re-llenar `SpawnPointsIndex` con los puntos disponibles
            for (int m = 0; m < Utilidades.notAvailableSpawnPoints.Length; m++)
            {
                if (!Utilidades.notAvailableSpawnPoints[m])
                {
                    SpawnPointsIndex.Add(m);
                }
            }
        }

        if (SpawnPointsIndex.Count > 0)
        {
            // Generación de un índice aleatorio basado en los puntos disponibles
            p = Rand.Next(SpawnPointsIndex.Count);
            spawnIndex = SpawnPointsIndex[p];

            Debug.Log($"Spawning at index: {spawnIndex}");

            // Remover el índice seleccionado de `SpawnPointsIndex` y marcarlo como ocupado
            SpawnPointsIndex.RemoveAt(p);
            Utilidades.notAvailableSpawnPoints[spawnIndex] = true;

            // Inicializamos `newTarget` a null
            GameObject newTarget = null;

            if (Utilidades.hasStarted == false)
            {
                newTarget = null;
            }
            else
            {
                if (Utilidades.selectedProcedure == "Resistencia" && (Utilidades.currentPhase == 0 || Utilidades.currentPhase == 2))
                {
                    newTarget = Instantiate(targetPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
                }
                else if (Utilidades.selectedProcedure == "Resistencia" && (Utilidades.currentPhase == 1 || Utilidades.currentPhase == 3))
                {
                    newTarget = Instantiate(targetPrefab2, spawnPoints[spawnIndex].position, Quaternion.identity);
                }
                else if (Utilidades.selectedProcedure == "Renovación" && Utilidades.currentPhase == 1 || Utilidades.currentPhase == 3)
                {
                    newTarget = Instantiate(targetPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
                }
                else if (Utilidades.selectedProcedure == "Renovación" && Utilidades.currentPhase == 2)
                {
                    newTarget = Instantiate(targetPrefab2, spawnPoints[spawnIndex].position, Quaternion.identity);
                }
                else if ((Utilidades.selectedProcedure == "Restablecimiento" || Utilidades.selectedProcedure == "Resurgimiento") && (Utilidades.currentPhase == 1 || Utilidades.currentPhase == 2 || Utilidades.currentPhase == 3))
                {
                    newTarget = Instantiate(targetPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
                }


                if (newTarget != null)
                {
                    // Asignar el índice del punto de spawn al objeto instanciado
                    newTarget.AddComponent<SpawnedObject>().spawnIndex = spawnIndex;

                    currentTargets.Add(newTarget);
                }
            }
        }
        else
        {
           // Debug.Log("No hay puntos de spawn disponibles.");
        }
    }



}


