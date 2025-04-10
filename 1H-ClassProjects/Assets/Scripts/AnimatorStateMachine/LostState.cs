using UnityEngine;

public class LostState : BaseState
{
    [SerializeField, Tooltip("How long should the camera remain confused")] private float confusionDuration = 3;
    // the time at which transition to patrol should happen
    private float transitionTime;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        
        transitionTime = Time.time + confusionDuration;
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (SeePlayer(animator))
        {
            animator.SetInteger("CameraState", 1);
        }
        else if(Time.time > transitionTime)
        {
            animator.SetInteger("CameraState", 0);
        }
    }
}
