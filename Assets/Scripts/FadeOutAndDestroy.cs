using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FadeOutAndDestroy : MonoBehaviour
{
    public float fadeDuration = 2.0f; // Duration of the fade-out effect
    private List<Material> materials = new List<Material>();
    private List<Color> originalColors = new List<Color>();

    void Start()
    {
        // Get the materials of the object and its children
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            materials.Add(renderer.material);
            originalColors.Add(renderer.material.color);
        }
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1.0f, 0.0f, elapsedTime / fadeDuration);
            for (int i = 0; i < materials.Count; i++)
            {
                materials[i].color = new Color(originalColors[i].r, originalColors[i].g, originalColors[i].b, alpha);
            }
            yield return null;
        }

        Destroy(gameObject); // Destroy the object and its children after fading out
    }
}
