using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleNumericKeypad : MonoBehaviour
{
    private TMP_InputField activeInputField; // InputField seleccionado

    // Esta funci�n ser� llamada cuando el InputField sea seleccionado (por ejemplo, al hacer clic en �l)
    public void SetActiveInputField(TMP_InputField inputField)
    {
        activeInputField = inputField;
    }

    // Esta funci�n ser� llamada al presionar un bot�n del teclado num�rico
    public void OnNumberButtonPressed(string number)
    {
        if (activeInputField != null)
        {
            activeInputField.text += number; // Agrega el n�mero al InputField activo
        }
    }

    // Esta funci�n puede usarse para borrar el contenido del InputField
    public void OnClearButtonPressed()
    {
        if (activeInputField != null)
        {
            activeInputField.text = ""; // Limpia el contenido del InputField activo
        }
    }
}
