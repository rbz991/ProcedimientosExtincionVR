using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartProgram : MonoBehaviour
{
    
    public void StartNow()
    {
        Utilidades.StartProgram = true;
        Utilidades.hasStarted = true;

        //GameObject myObject = GameObject.Find("Spatial Panel Manipulator Model");
        //VisibilityController myVisCon = myObject.GetComponent<VisibilityController>(); ;
        //myVisCon.Hide();

    }
}
