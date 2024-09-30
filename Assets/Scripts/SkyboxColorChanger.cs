using UnityEngine;

public class SkyboxColorChanger : MonoBehaviour
{
    public Material saveSkybox;
    public Material skyboxMaterial;  // Assign this through the Inspector
    public Material skyboxMaterial2;  // Assign this through the Inspector
    public GameObject myPartSys;
    //public Color targetColor1 = Color.blue;  // Set your target color in the Inspector
    //public Color targetColor2 = Color.blue;  // Set your target color in the Inspector
    private void Start()
    {
        myPartSys.SetActive(false);
    }

    void Update()
    {
               
        if (Utilidades.selectedProcedure == "Resistencia")
        {
            if (Utilidades.currentPhase == 1)
            {
                myPartSys.SetActive(true);
                skyboxMaterial.Lerp(skyboxMaterial, skyboxMaterial2, Time.deltaTime * 0.2f);
            }
            if (Utilidades.currentPhase == 2)
            {
                myPartSys.SetActive(false);
                skyboxMaterial.Lerp(skyboxMaterial, saveSkybox, Time.deltaTime * 0.2f);
            }
            if (Utilidades.currentPhase == 3)
            {
                myPartSys.SetActive(true);
                skyboxMaterial.Lerp(skyboxMaterial, skyboxMaterial2, Time.deltaTime * 0.2f);
            }
            if (Utilidades.currentPhase == 4)
            {
                myPartSys.SetActive(false);
                skyboxMaterial.Lerp(skyboxMaterial, saveSkybox, Time.deltaTime * 0.2f);
            }
            if (Utilidades.currentPhase == 5)
            {
                myPartSys.SetActive(false);
                skyboxMaterial.Lerp(skyboxMaterial, saveSkybox, Time.deltaTime * 0.2f);
            }
        }
        else if (Utilidades.selectedProcedure == "Renovación")
        {
            if (Utilidades.currentPhase == 2)
            {
                myPartSys.SetActive(true);
                skyboxMaterial.Lerp(skyboxMaterial, skyboxMaterial2, Time.deltaTime * 0.2f);
            }
            if (Utilidades.currentPhase == 3)
            {
                myPartSys.SetActive(false);
                skyboxMaterial.Lerp(skyboxMaterial, saveSkybox, Time.deltaTime * 0.2f);
            }
           

        }
        else 
        {
           

        }


    }
}
