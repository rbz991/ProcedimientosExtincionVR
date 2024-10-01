using UnityEngine;
using System.Collections;
using TMPro;

public class PhaseManager : MonoBehaviour
{
    public   TextMeshProUGUI tmpText;
    public TextMeshProUGUI tmpMesa;
    public GameObject tmpGracias;
    public GameObject secondGun;

    //public Material SkyboxMaterial1;
    //public Material SkyboxMaterial2;
    //public Color targetColorBlue = Color.blue;
    //public Color targetColorMag = Color.magenta;
    public GameObject targetObject;  // The GameObject that has the scripts to be toggled
    public string scriptNameToActivate1 = "TargetScript1";  // Name of the first script to activate
    public string scriptNameToActivate2 = "TargetScript2";  // Name of the second script to activate
    private int components;

    public VisibilityController visibilityController;

    public FadeOutAndDestroy[] fadeOutAndDestroy;
    public MusicFader musicFader;

    private void Update()
    {
        tmpText.text = Utilidades.points.ToString();
   
       
        if (Utilidades.StartProgram == true)
        {
            Utilidades.StartProgram = false;
            
            Utilidades.LogEvent("Procedimiento: " + Utilidades.selectedProcedure);
            Utilidades.LogEvent("Costo de respuesta: " + Utilidades.responseCost);
            visibilityController.Show();
            if (Utilidades.selectedProcedure == "Resistencia")
            {
                Utilidades.LogEvent("Duración de componentes: " + Utilidades.componentDuration);
                Utilidades.LogEvent("Comenzó en rico: " + Utilidades.startRich);
                Utilidades.LogEvent("IV Rico: " + Utilidades.valueVIRico);
                Utilidades.LogEvent("IV Pobre: " + Utilidades.valueVIPobre);
            }
            else
            {
                Utilidades.LogEvent("Valor IV: " + Utilidades.valueVI);
                Utilidades.LogEvent("Duracion Fase 1: " + Utilidades.phase1Duration);
                Utilidades.LogEvent("Duracion Fase 2: " + Utilidades.phase2Duration);
                Utilidades.LogEvent("Duracion Fase 3: " + Utilidades.phase3Duration);
            }

            if (Utilidades.responseCost == true)
            {
                Utilidades.points = 1000;
            }
           
            
            StartCoroutine(StartNextPhase());
        }

    }

    void Start()
    {
        secondGun.SetActive(false);
        tmpGracias.SetActive(false);
        Utilidades.StartLogging();
        components = 5;
        
    }

     IEnumerator StartNextPhase()
    {
       
        while (Utilidades.currentPhase < components)
        {
            if (Utilidades.currentPhase == 0)
            {
                fadeOutAndDestroy[0].StartFadeOut();
                fadeOutAndDestroy[1].StartFadeOut();
                fadeOutAndDestroy[2].StartFadeOut();
                musicFader.enabled = true;
                Utilidades.LogEvent("Procedure started.");
            }
           
            Debug.Log("Phase " + Utilidades.currentPhase + " started.");
            yield return new WaitForSeconds(Utilidades.phaseDurations[Utilidades.currentPhase]);
            
            
            Utilidades.currentPhase++;
            ResetSpawnPoints();
            if (Utilidades.currentPhase < 5) /*Utilidades.LogEvent("Phase " + Utilidades.currentPhase + " started.");*/
            Debug.Log("Phase " + Utilidades.currentPhase + " started.");


            if (Utilidades.currentPhase == 4)
            {
                tmpGracias.SetActive(true);
                //musicFader.enabled = false;

                Utilidades.LogEvent("Puntos: " + Utilidades.points);
                Utilidades.LogEvent("Refs: " + Utilidades.refs);

                if (Utilidades.selectedProcedure == "Resistencia")
                {
                    Utilidades.LogEvent("Refs Rico: " + Utilidades.refsRico);
                    Utilidades.LogEvent("Refs Pobre: " + Utilidades.refsPobre);
                    Utilidades.LogEvent("Shoot Rico: " + Utilidades.shootRico);
                    Utilidades.LogEvent("Shoot Pobre: " + Utilidades.shootPobre);
                    Utilidades.LogEvent("Hit Rico: " + Utilidades.hitRico);
                    Utilidades.LogEvent("Hit Pobre: " + Utilidades.hitPobre);
                }
                   


                //musicFader.enabled = false;


                //Poner esto en el boton de gracias
                
            }

        }

        
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
