using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class VRNumericKeypad : MonoBehaviour
{
    private GameObject lastSelectedInputField; // Guarda el último InputField seleccionado
    public void OnNumberButtonPressed(string number)
    {
        // Obtener el objeto actualmente seleccionado
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        // Verificar si el objeto seleccionado es un InputField
        if (selectedObject != null && selectedObject.GetComponent<TMP_InputField>() != null)
        {
            lastSelectedInputField = selectedObject; // Almacenar el InputField activo
            TMP_InputField activeInputField = selectedObject.GetComponent<TMP_InputField>();
            activeInputField.text += number; // Agregar el número al InputField activo
        }
        else if (lastSelectedInputField != null) // Si no hay nada seleccionado pero tenemos un InputField previo
        {
            TMP_InputField activeInputField = lastSelectedInputField.GetComponent<TMP_InputField>();
            activeInputField.text += number; // Agregar el número al InputField previo
        }

        // Reasignar el InputField activo como seleccionado
        if (lastSelectedInputField != null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelectedInputField);
        }
    }

    // Función opcional para borrar el contenido del InputField activo
    public void OnClearButtonPressed()
    {
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        if (selectedObject != null && selectedObject.GetComponent<TMP_InputField>() != null)
        {
            TMP_InputField activeInputField = selectedObject.GetComponent<TMP_InputField>();
            activeInputField.text = ""; // Limpiar el contenido del InputField activo
        }
    }
}
