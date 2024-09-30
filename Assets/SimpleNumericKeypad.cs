using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleNumericKeypad : MonoBehaviour
{
    private TMP_InputField activeInputField; // InputField seleccionado

    // Esta función será llamada cuando el InputField sea seleccionado (por ejemplo, al hacer clic en él)
    public void SetActiveInputField(TMP_InputField inputField)
    {
        activeInputField = inputField;
    }

    // Esta función será llamada al presionar un botón del teclado numérico
    public void OnNumberButtonPressed(string number)
    {
        if (activeInputField != null)
        {
            activeInputField.text += number; // Agrega el número al InputField activo
        }
    }

    // Esta función puede usarse para borrar el contenido del InputField
    public void OnClearButtonPressed()
    {
        if (activeInputField != null)
        {
            activeInputField.text = ""; // Limpia el contenido del InputField activo
        }
    }
}
