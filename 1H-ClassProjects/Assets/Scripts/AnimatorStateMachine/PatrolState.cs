using UnityEngine;

public class PatrolState : BaseState
{
    [SerializeField, Tooltip("How fast the camera rotates in patrol mode")] private float rotationSpeed = 45;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // change the color only once
        animator.gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        
        if (SeePlayer(animator))
        {
            animator.SetInteger("CameraState", 1);
        }
    }
}
