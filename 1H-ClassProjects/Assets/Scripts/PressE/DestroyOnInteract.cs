using UnityEngine;

public class DestroyOnInteract : MonoBehaviour, IInteractable
{
    /// <summary>
    /// The simplest way of interacting: Destruction. (easier than creating something pretty)
    /// </summary>
    public void Interact()
    {
        Destroy(gameObject);
    }
}
