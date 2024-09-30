using UnityEngine;
using UnityEngine.InputSystem;

public class DisableMovement : MonoBehaviour
{
    public InputActionProperty joystickInput; // Asocia el joystick que est�s usando

    void Start()
    {
        // Desactivar el joystick input
        joystickInput.action.Disable();
    }
}
