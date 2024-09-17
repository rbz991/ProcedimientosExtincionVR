using UnityEngine;
using UnityEngine.UI;

public class GlobosSimultaneosSlide : MonoBehaviour
{
    public Slider mySlider; // Este campo debe ser público

   

    public void SliderVal()
    {
        Utilidades.GlobosSimultaneos = (int)mySlider.value;
        Debug.Log("Valor actual del Slider: " + Utilidades.GlobosSimultaneos);
    }
}
