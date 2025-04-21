using UnityEngine;

public class ColliderVisibilityOptimizer : MonoBehaviour
{
    private Renderer objectRenderer;
    private Collider objectCollider;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (objectRenderer.isVisible)
        {
            objectCollider.enabled = true;
        }
        else
        {
            objectCollider.enabled = false;
        }
    }
}
