using UnityEngine;
using UnityEngine.InputSystem;

public enum ViewType
{
    Static,
    LookAt,
    TopDown
}

public class FollowPlayer : MonoBehaviour
{
    private Transform targetTransform;
    private int targetIndex = 0;

    [SerializeField] private ViewType viewType;
    [SerializeField] private float cameraHeight;

    [SerializeField] private Transform[] targets;

    private InputAction switchCameraAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // look for the player
        targetTransform = targets[targetIndex];
        switchCameraAction = InputSystem.actions.FindAction("Jump");
        switchCameraAction.performed += SwitchTarget;
    }

    private void SwitchTarget(InputAction.CallbackContext obj)
    {
        targetIndex = ++targetIndex % targets.Length;
        targetTransform = targets[targetIndex];
    }

    // Update is called once per frame
    void Update()
    {
        switch (viewType)
        {
            case ViewType.LookAt:
                transform.LookAt(targetTransform.position);
                break;
            case ViewType.TopDown:
                transform.position = targetTransform.position + Vector3.up * cameraHeight;
                transform.LookAt(targetTransform.position);
                break;
            case ViewType.Static:
                break;
        }
        
    }
}
