using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class SubmitParameters : MonoBehaviour
{
    public GameObject secondGun;
    public void SubmitParams()
    {
        if (Utilidades.selectedProcedure != null) {
            GameObject myObject = GameObject.Find("Spatial Panel Manipulator UI Examples");
            VisibilityController myVisCon = myObject.GetComponent<VisibilityController>(); ;
            myVisCon.Hide();

           if (Utilidades.selectedProcedure == "Resistencia")
            {
                GameObject myCDur = GameObject.Find("InputField C Dur");
                TMP_InputField myInputCDur =  myCDur.GetComponent<TMP_InputField>();
                GameObject myIVR = GameObject.Find("InputField IV R");
                TMP_InputField myInputIVR = myIVR.GetComponent<TMP_InputField>();
                GameObject myIVP = GameObject.Find("InputField IV P");
                TMP_InputField myInputIVP = myIVP.GetComponent<TMP_InputField>();

                Utilidades.componentDuration = int.Parse(myInputCDur.text);
                Utilidades.valueVIRico = int.Parse(myInputIVR.text);
                Utilidades.valueVIPobre = int.Parse(myInputIVP.text);
            }
           else if (Utilidades.selectedProcedure == "Renovación")
            {
                GameObject myIVReno = GameObject.Find("InputField IV Reno");
                TMP_InputField myInputIVReno = myIVReno.GetComponent<TMP_InputField>();
                GameObject myP1Reno = GameObject.Find("InputField P1 Reno");
                TMP_InputField myInputP1Reno = myP1Reno.GetComponent<TMP_InputField>();
                GameObject myP2Reno = GameObject.Find("InputField P2 Reno");
                TMP_InputField myInputP2Reno = myP2Reno.GetComponent<TMP_InputField>();
                GameObject myP3Reno = GameObject.Find("InputField P3 Reno");
                TMP_InputField myInputP3Reno = myP3Reno.GetComponent<TMP_InputField>();

                Utilidades.valueVI = int.Parse(myInputIVReno.text);
                Utilidades.phase1Duration = int.Parse(myInputP1Reno.text);
                Utilidades.phase2Duration = int.Parse(myInputP2Reno.text);
                Utilidades.phase3Duration = int.Parse(myInputP3Reno.text);
            }
            else if (Utilidades.selectedProcedure == "Resurgimiento")
            {
                GameObject myIVResu = GameObject.Find("InputField IV Resu");
                TMP_InputField myInputIVResu = myIVResu.GetComponent<TMP_InputField>();
                GameObject myP1Resu = GameObject.Find("InputField P1 Resu");
                TMP_InputField myInputP1Resu = myP1Resu.GetComponent<TMP_InputField>();
                GameObject myP2Resu = GameObject.Find("InputField P2 Resu");
                TMP_InputField myInputP2Resu = myP2Resu.GetComponent<TMP_InputField>();
                GameObject myP3Resu = GameObject.Find("InputField P3 Resu");
                TMP_InputField myInputP3Resu = myP3Resu.GetComponent<TMP_InputField>();
               
                if (Utilidades.TimeOut == true)
                {
                GameObject myTO = GameObject.Find("InputField TO");
                TMP_InputField myInputTO = myTO.GetComponent<TMP_InputField>();
                Utilidades.timeOutDuration = int.Parse(myInputTO.text);
                }
                

                Utilidades.valueVI = int.Parse(myInputIVResu.text);
                Utilidades.phase1Duration = int.Parse(myInputP1Resu.text);
                Utilidades.phase2Duration = int.Parse(myInputP2Resu.text);
                Utilidades.phase3Duration = int.Parse(myInputP3Resu.text);
                
                secondGun.SetActive(true);
            }
            else if (Utilidades.selectedProcedure == "Restablecimiento")
            {
                GameObject myIVRest = GameObject.Find("InputField IV Rest");
                TMP_InputField myInputIVRest = myIVRest.GetComponent<TMP_InputField>();
                GameObject myP1Rest = GameObject.Find("InputField P1 Rest");
                TMP_InputField myInputP1Rest = myP1Rest.GetComponent<TMP_InputField>();
                GameObject myP2Rest = GameObject.Find("InputField P2 Rest");
                TMP_InputField myInputP2Rest = myP2Rest.GetComponent<TMP_InputField>();
                GameObject myP3Rest = GameObject.Find("InputField P3 Rest");
                TMP_InputField myInputP3Rest = myP3Rest.GetComponent<TMP_InputField>();
                GameObject myRefInd = GameObject.Find("InputField Ref Ind");
                TMP_InputField myInputRefInd = myRefInd.GetComponent<TMP_InputField>();

                Utilidades.valueVI = int.Parse(myInputIVRest.text);
                Utilidades.phase1Duration = int.Parse(myInputP1Rest.text);
                Utilidades.phase2Duration = int.Parse(myInputP2Rest.text);
                Utilidades.phase3Duration = int.Parse(myInputP3Rest.text);
                Utilidades.restabTV = int.Parse(myInputRefInd.text);
                

            }

            if (Utilidades.selectedProcedure == "Resistencia")
            {
                for (int i = 0; i < 4; i++) // El bucle se ejecuta mientras i sea menor que 5
                {
                    Utilidades.phaseDurations[i] = Utilidades.componentDuration;
                }
                Utilidades.phaseDurations[4] = .0001f;
            }
            else
            {
                Utilidades.phaseDurations[0] = .0001f;
                Utilidades.phaseDurations[1] = Utilidades.phase1Duration;
                Utilidades.phaseDurations[2] = Utilidades.phase2Duration;
                Utilidades.phaseDurations[3] = Utilidades.phase3Duration;
                Utilidades.phaseDurations[4] = .0001f;
            }

            Debug.Log(Utilidades.phaseDurations[0]);
            Debug.Log(Utilidades.phaseDurations[1]);
            Debug.Log(Utilidades.phaseDurations[2]);
            Debug.Log(Utilidades.phaseDurations[3]);
            Debug.Log(Utilidades.phaseDurations[4]);



        }
    }
}
