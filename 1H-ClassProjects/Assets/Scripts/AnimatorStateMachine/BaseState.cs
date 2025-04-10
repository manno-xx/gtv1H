using UnityEngine;

/// <summary>
/// Base class for all states so the seeing of the player can be defined here
/// </summary>
public class BaseState : StateMachineBehaviour
{
    [SerializeField] private float maxViewDistance = 10;
    
    /// <summary>
    /// Raycast in transform.forward direction.
    /// If ray hits player, return true, otherwise, false
    /// </summary>
    /// <param name="animator"></param>
    /// <returns></returns>
    protected bool SeePlayer(Animator animator)
    {
        if (Physics.Raycast(
                animator.transform.position, 
                animator.transform.forward, 
                out RaycastHit hitInfo, 
                maxViewDistance))
        {

            return hitInfo.transform.CompareTag("Player");
        }

        return false;
    }
}
