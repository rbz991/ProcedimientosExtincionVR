using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using TMPro;

public class PhaseManager : MonoBehaviour
{
    public   TextMeshProUGUI tmpText;
    public TextMeshProUGUI tmpMesa;
    public GameObject tmpGracias;
   
    public static int points = 1000;
    public static int refs;
    public static int shootRico;
    public static int shootPobre;
    public static int hitRico;
    public static int hitPobre;
    public static int refsRico;
    public static int refsPobre;
    public float[] phaseDurations; // Duration of each phase in minutes
    public static int currentPhase = 0;
    public Material SkyboxMaterial1;
    public Material SkyboxMaterial2;
    public Color targetColorBlue = Color.blue;
    public Color targetColorMag = Color.magenta;
    public GameObject targetObject;  // The GameObject that has the scripts to be toggled
    public string scriptNameToActivate1 = "TargetScript1";  // Name of the first script to activate
    public string scriptNameToActivate2 = "TargetScript2";  // Name of the second script to activate
    private int components;

    public VisibilityController visibilityController;
    public FadeOutAndDestroy[] fadeOutAndDestroy;
    public MusicFader musicFader;

    private void Update()
    {
        tmpText.text = points.ToString();
       // tmpMesa.text = points.ToString();
       
        if (Utilidades.StartProgram == true)
        {
            Utilidades.StartProgram = false;
            Utilidades.StartLogging();
            Utilidades.LogEvent("Comienza en rico: " + Utilidades.startRich);
            visibilityController.Show();
            points = 1000;
            StartCoroutine(StartNextPhase());
        }

    }

    void Start()
    {
        ////SkyboxMaterial1 = RenderSettings.skybox;
        //if (phaseDurations.Length < 5)
        // {
        // Debug.LogError("Please set all 5 phase durations in the inspector.");
        //  return;
        // }
        tmpGracias.SetActive(false);
        components = phaseDurations.Length;
        
    }

     IEnumerator StartNextPhase()
    {
        
        while (currentPhase < components)
        {
            yield return new WaitForSeconds(phaseDurations[currentPhase] * 60);

            currentPhase++;
            TriggerPhaseActions(currentPhase);
            
            
            if (currentPhase == 1)
            {
                fadeOutAndDestroy[0].StartFadeOut();
                fadeOutAndDestroy[1].StartFadeOut();
                fadeOutAndDestroy[2].StartFadeOut();
                musicFader.enabled = true;
               
            }

            if (points < 1)
            {
                currentPhase = 14;
                components = 14;
               
            }

            if (currentPhase == 13)
            {
                tmpGracias.SetActive(true);
            }

                if (currentPhase == 14)
            {
               Utilidades.LogEvent("Puntos: " + points);
                Utilidades.LogEvent("Refs: " + refs);
                Utilidades.LogEvent("Refs Rico: " + refsRico);
                Utilidades.LogEvent("Refs Pobre: " + refsPobre);
                Utilidades.LogEvent("Shoot Rico: " + shootRico);
                Utilidades.LogEvent("Shoot Pobre: " + shootPobre);
                Utilidades.LogEvent("Hit Rico: " + hitRico);
                Utilidades.LogEvent("Hit Pobre: " + hitPobre);
                musicFader.enabled = false;
                Application.Quit();

                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif


            }

        }

        
    }

    void TriggerPhaseActions(int phase)
    {
        ResetSpawnPoints();
        Debug.Log("Phase " + phase + " started.");

        //switch (phase)
        //{
        //    case 1:
        //        ToggleScripts(true, false);
        //        break;
        //    case 3:
        //        ToggleScripts(true, false);
        //        break;
        //    case 2:
        //        ToggleScripts(false, true);
        //        break;
        //    case 4:
        //        ToggleScripts(false, true);
        //        break;
        //    case 5:
        //        ToggleScripts(false, false);
        //        break;
        //}
    }

    void ToggleScripts(bool enableScript1, bool enableScript2)
    {
        MonoBehaviour script1 = targetObject.GetComponent(scriptNameToActivate1) as MonoBehaviour;
        MonoBehaviour script2 = targetObject.GetComponent(scriptNameToActivate2) as MonoBehaviour;

        if (script1 != null && script2 != null)
        {
            script1.enabled = enableScript1;
            script2.enabled = enableScript2;
            Debug.Log($"{scriptNameToActivate1} enabled: {enableScript1}, {scriptNameToActivate2} enabled: {enableScript2}");
        }
        else
        {
            Debug.LogError("One or both scripts not found on the target object.");
        }
    }

    void FinishProgram()
    {
        Utilidades.LogEvent("points," + points);
        Debug.Log("All phases completed. Program will finish.");
    }

    private void ResetSpawnPoints()
    {
        // Resetea todos los puntos de spawn como disponibles
        for (int m = 0; m < Utilidades.notAvailableSpawnPoints.Length; m++)
        {
            Utilidades.notAvailableSpawnPoints[m] = false;
        }

        // Limpia y repuebla la lista de puntos disponibles
        Utilidades.SpawnPointsIndex.Clear();
        for (int m = 0; m < Utilidades.notAvailableSpawnPoints.Length; m++)
        {
            Utilidades.SpawnPointsIndex.Add(m);
        }

        Debug.Log("Spawn points reseteados.");
    }

}
