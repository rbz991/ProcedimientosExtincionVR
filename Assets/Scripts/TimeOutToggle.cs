using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeOutToggle : MonoBehaviour
{
    public Toggle myToggle;

    public void ToggleVal()
    {
        if (myToggle.isOn == true)
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
