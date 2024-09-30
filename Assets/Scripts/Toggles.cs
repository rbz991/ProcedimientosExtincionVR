
using UnityEngine;
using UnityEngine.UI;



public class Toggles : MonoBehaviour
{
    public Toggle myToggleResponseCost;
    public Toggle myToggleStartRich;
    public Toggle myToggleTimeOut;

    public void ToggleResponseCost()
    {
        if (myToggleResponseCost.isOn)
        {
            Utilidades.responseCost = true;
            Debug.Log("Costo de respuesta: " + Utilidades.responseCost);
        }
        else
        {
            Utilidades.responseCost = false;
            Debug.Log("Costo de respuesta: " + Utilidades.responseCost);
        }
    }

    public void ToggleStartRich()
    {
        if (myToggleStartRich.isOn)
        {
            Utilidades.startRich = true;
            Debug.Log("Comienza en rico: " + Utilidades.startRich);
        }
        else
        {
            Utilidades.startRich = false;
            Debug.Log("Comienza en rico: " + Utilidades.startRich);
        }
    }

    public void ToggleTimeOut()
    {
        if (myToggleTimeOut.isOn == true)
        {
            Utilidades.TimeOut = true;
            Debug.Log("Time Out activo: " + Utilidades.TimeOut);
        }
        else
        {
            Utilidades.TimeOut = false;
            Debug.Log("Time Out activo: " + Utilidades.TimeOut);
        }
    }
}
