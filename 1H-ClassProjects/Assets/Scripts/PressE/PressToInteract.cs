using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script to register E-presses (or whatever is defined to interact
/// If the key is pressed, a ray is cast.
/// If an IInteractable was hit by the ray,
/// interact with it 
/// </summary>
public class PressToInteract : MonoBehaviour
{
    [SerializeField] private float minimalInteractionDistance;
    
    void Start()
    {
        InputAction interact = InputSystem.actions.FindAction("Interact");
        interact.started += OnEPressed;
    }
    
    /// <summary>
    /// When the interact key is pressed
    /// </summary>
    /// <param name="obj"></param>
    private void OnEPressed(InputAction.CallbackContext obj)
    {
        if (Physics.Raycast(
                transform.position, 
                transform.forward, 
                out RaycastHit hitInfo, 
                minimalInteractionDistance))
        {
            if (hitInfo.transform.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
    }
}
