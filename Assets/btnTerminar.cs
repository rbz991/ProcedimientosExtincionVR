using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnTerminar : MonoBehaviour
{
    // Start is called before the first frame update
    public void Concluir()
    {
        Utilidades.LogEvent("Sesion concluida.");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
