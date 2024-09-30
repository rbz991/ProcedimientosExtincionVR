using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProcedureSelect : MonoBehaviour
{
    private TMP_Dropdown myDropdown;
    void Start()
    {
        // Obtén el componente Dropdown del mismo objeto
        myDropdown = GetComponent<TMP_Dropdown>();
    }
    public void DropdownProcedureSelect()
    {
        int selectedIndex = myDropdown.value; // Obtiene el índice seleccionado
        string selectedText = myDropdown.options[selectedIndex].text; // Obtiene el texto del elemento seleccionado
        Utilidades.selectedProcedure = selectedText;
       
        GameObject myParams = GameObject.Find("Params");
        VisibilityController myVisParams = myParams.GetComponent<VisibilityController>(); 
        myVisParams.Hide();
        if (Utilidades.selectedProcedure == "Resistencia" )
        {
            GameObject myObject = GameObject.Find("ParamResistencia");
            VisibilityController myVisCon = myObject.GetComponent<VisibilityController>(); ;
            myVisCon.Show();
        }
        else if (Utilidades.selectedProcedure == "Renovación")
        {
            GameObject myObject = GameObject.Find("ParamRenovacion");
            VisibilityController myVisCon = myObject.GetComponent<VisibilityController>(); ;
            myVisCon.Show();
        }
        else if (Utilidades.selectedProcedure == "Resurgimiento")
        {
            GameObject myObject = GameObject.Find("ParamResurgimiento");
            VisibilityController myVisCon = myObject.GetComponent<VisibilityController>(); ;
            myVisCon.Show();
        }
        else if (Utilidades.selectedProcedure == "Restablecimiento")
        {
            GameObject myObject = GameObject.Find("ParamRestablecimiento");
            VisibilityController myVisCon = myObject.GetComponent<VisibilityController>(); ;
            myVisCon.Show();
        }

    }


}
