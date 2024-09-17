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
        if ((PhaseManager.currentPhase == 1 || PhaseManager.currentPhase == 3 || PhaseManager.currentPhase == 5 || PhaseManager.currentPhase == 7 || PhaseManager.currentPhase == 9 || PhaseManager.currentPhase == 11) && !isFadingOut)
        {
            StartCoroutine(FadeIn(audioSource1, audioSource2));
        }
        else if ((PhaseManager.currentPhase == 2 || PhaseManager.currentPhase == 4 || PhaseManager.currentPhase == 6 || PhaseManager.currentPhase == 8 || PhaseManager.currentPhase == 10 || PhaseManager.currentPhase == 12) && !isFadingOut)
        {
            StartCoroutine(FadeIn(audioSource2, audioSource1));
        }
        else if ((PhaseManager.currentPhase == 13) && !isFadingOut)
        {
            audioSource1.volume = 0f;
            audioSource2.volume = 0f;
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