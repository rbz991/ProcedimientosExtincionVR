using UnityEngine;
using System.Collections;

public class MusicFader : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public float fadeDuration = 2.0f;
    private bool isFadingOut = false;
    //private PhaseManager phaseManager;

    void Start()
    {
        // Get the reference to the other script
        //phaseManager = FindObjectOfType<PhaseManager>();

        //if (phaseManager == null)
       // {
        //    Debug.LogError("OtherScript not found!");
       // }

        // Start with both audio sources  muted
        audioSource1.volume = 0.5f;
        audioSource2.volume = 0f;
        audioSource1.Play();
        audioSource2.Play();
    }

    void Update()
    {
        // Check the variable from the other script
        // if (phaseManager != null)
        // {

        if (Utilidades.selectedProcedure == "Resistencia")
        {
            if (Utilidades.currentPhase == 0 || Utilidades.currentPhase == 2)
            {
                StartCoroutine(FadeIn(audioSource1, audioSource2));
            }
            else if (Utilidades.currentPhase == 1 || Utilidades.currentPhase == 3)
            {
                StartCoroutine(FadeIn(audioSource2, audioSource1));
            }
            else 
            {
                audioSource1.Stop();
                audioSource2.Stop();
            }

        }
        else if (Utilidades.selectedProcedure == "Renovación")
        {
            if (Utilidades.currentPhase == 1 || Utilidades.currentPhase == 3)
            {
                StartCoroutine(FadeIn(audioSource1, audioSource2));
            }
            else if (Utilidades.currentPhase == 2)
            {
                StartCoroutine(FadeIn(audioSource2, audioSource1));
            }
            else if ((Utilidades.currentPhase == 4) && !isFadingOut)
            {
                audioSource1.volume = 0f;
                audioSource2.volume = 0f;
            }
        }
        else
        {
            StartCoroutine(FadeIn(audioSource1, audioSource2));
        }
       
      //  }
    }

    private IEnumerator FadeIn(AudioSource fadeInSource, AudioSource fadeOutSource)
    {
        isFadingOut = true;
        float startVolumeOut = fadeOutSource.volume;
        float startVolumeIn = fadeInSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            fadeOutSource.volume = Mathf.Lerp(startVolumeOut, 0.0f, t / fadeDuration);
            fadeInSource.volume = Mathf.Lerp(startVolumeIn, 0.5f, t / fadeDuration);
            yield return null;
        }

        fadeOutSource.volume = 0.0f;
        fadeInSource.volume = 0.5f;
        isFadingOut = false;
    }
}