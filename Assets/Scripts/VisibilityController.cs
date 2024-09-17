using UnityEngine;

public class VisibilityController : MonoBehaviour
{


    public void Start()
    {
        Hide();
       
    }


    // Método público para ocultar el GameObject y sus hijos
    public void Hide()
    {
        SetRenderersVisibility(false);
    }

    // Método público para mostrar el GameObject y sus hijos
    public void Show()
    {
        SetRenderersVisibility(true);
    }

    // Método privado para ajustar la visibilidad de los Renderers
    private void SetRenderersVisibility(bool isVisible)
    {
        // Desactivar MeshRenderer
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>(true);
        foreach (MeshRenderer renderer in meshRenderers)
        {
            renderer.enabled = isVisible;
        }

        // Desactivar SpriteRenderer
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>(true);
        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            renderer.enabled = isVisible;
        }

        // Desactivar SkinnedMeshRenderer
        SkinnedMeshRenderer[] skinnedRenderers = GetComponentsInChildren<SkinnedMeshRenderer>(true);
        foreach (SkinnedMeshRenderer renderer in skinnedRenderers)
        {
            renderer.enabled = isVisible;
        }

        // Desactivar componentes de UI
        UnityEngine.UI.Graphic[] uiGraphics = GetComponentsInChildren<UnityEngine.UI.Graphic>(true);
        foreach (UnityEngine.UI.Graphic graphic in uiGraphics)
        {
            graphic.enabled = isVisible;
        }

        // Desactivar Particle Systems
        ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>(true);
        foreach (ParticleSystem ps in particleSystems)
        {
            if (isVisible)
                ps.Play();
            else
                ps.Stop();
        }

        // Desactivar LineRenderer
        LineRenderer[] lineRenderers = GetComponentsInChildren<LineRenderer>(true);
        foreach (LineRenderer lineRenderer in lineRenderers)
        {
            lineRenderer.enabled = isVisible;
        }
    }

}
