using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StartRich : MonoBehaviour
{

    public TMP_Dropdown myDropdown;

    public void DropdownVal()
    {
       if (myDropdown.captionText.text == "Option A")
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
}
