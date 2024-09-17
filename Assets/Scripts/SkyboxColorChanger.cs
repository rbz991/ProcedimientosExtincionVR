using UnityEngine;

public class SkyboxColorChanger : MonoBehaviour
{
    public Material saveSkybox;
    public Material skyboxMaterial;  // Assign this through the Inspector
    public Material skyboxMaterial2;  // Assign this through the Inspector
    public Color targetColor1 = Color.blue;  // Set your target color in the Inspector
    public Color targetColor2 = Color.blue;  // Set your target color in the Inspector


   

    void Update()
    {



        //skyboxMaterial.Lerp(skyboxMaterial, skyboxMaterial2, Time.deltaTime * 0.05f);   






       
        if (PhaseManager.currentPhase == 1 ) {
           
           // skyboxMaterial.SetColor("_Tint", Color.Lerp(targetColor1, targetColor2, Time.deltaTime * 0.5f));
        }
        if (PhaseManager.currentPhase == 2)
        {
            skyboxMaterial.Lerp(skyboxMaterial, skyboxMaterial2, Time.deltaTime * 0.2f);
        }
        if (PhaseManager.currentPhase == 3)
        {
            skyboxMaterial.Lerp(skyboxMaterial, saveSkybox, Time.deltaTime * 0.2f);
        }
        if (PhaseManager.currentPhase == 4)
        {
            skyboxMaterial.Lerp(skyboxMaterial, skyboxMaterial2, Time.deltaTime * 0.2f);
        }
        if (PhaseManager.currentPhase == 5)
        {
            skyboxMaterial.Lerp(skyboxMaterial, saveSkybox, Time.deltaTime * 0.2f);
        }
        if (PhaseManager.currentPhase == 6)
        {
            skyboxMaterial.Lerp(skyboxMaterial, skyboxMaterial2, Time.deltaTime * 0.2f);
        }
        if (PhaseManager.currentPhase == 7)
        {
            skyboxMaterial.Lerp(skyboxMaterial, saveSkybox, Time.deltaTime * 0.2f);
        }
        if (PhaseManager.currentPhase == 8)
        {
            skyboxMaterial.Lerp(skyboxMaterial, skyboxMaterial2, Time.deltaTime * 0.2f);
        }
        if (PhaseManager.currentPhase == 9)
        {
            skyboxMaterial.Lerp(skyboxMaterial, saveSkybox, Time.deltaTime * 0.2f);
        }
        if (PhaseManager.currentPhase == 10)
        {
            skyboxMaterial.Lerp(skyboxMaterial, skyboxMaterial2, Time.deltaTime * 0.2f);
        }
        if (PhaseManager.currentPhase == 11)
        {
            skyboxMaterial.Lerp(skyboxMaterial, saveSkybox, Time.deltaTime * 0.2f);
        }
        if (PhaseManager.currentPhase == 12)
        {
            skyboxMaterial.Lerp(skyboxMaterial, skyboxMaterial2, Time.deltaTime * 0.2f);
        }
        if (PhaseManager.currentPhase == 13)
        {
            skyboxMaterial.Lerp(skyboxMaterial, saveSkybox, Time.deltaTime * 0.2f);
        }

        // Change the tint color gradually over time or based on some condition

    }
}
