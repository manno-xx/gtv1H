using UnityEngine;

/// <summary>
/// Door object. Opens or closes when you interact with it
/// Implements the IInteractable interface to be able to address it in a uniform way
/// </summary>
[RequireComponent(typeof(HingeJoint))]
public class Door : MonoBehaviour, IInteractable
{
    private HingeJoint hinge;
    
    private bool isOpen = false;
    
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }
    
    /// <summary>
    /// When interacted with: Opens or closes the door using the Hinge's Spring
    /// </summary>
    public void Interact()
    {
        JointSpring spring = hinge.spring;
        
        if(isOpen)
            spring.targetPosition = 0;
        else
            spring.targetPosition = 90;
        
        // or write the above as:
        // spring.targetPosition = isOpen ? 0 : 90;
        
        hinge.spring = spring;
        
        isOpen = !isOpen;
    }
}


