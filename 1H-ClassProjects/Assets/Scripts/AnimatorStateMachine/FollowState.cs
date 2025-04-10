using UnityEngine;

public class FollowState : BaseState
{
    private Transform playerTransform;

    [SerializeField, Tooltip("Rotation speed in degrees in tracking mode")] private float rotationSpeed;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        animator.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
    
    /// <summary>
    /// Check for LOS on player. If not, to lost state, otherwise rotate exactly towards player
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!SeePlayer(animator))
        {
             animator.SetInteger("CameraState", 2);
        }
        else
        {
            // look at the player (wherever it is)
            // from A - B = B - A
            // from camera to player = player position - camera position
            Vector3 towardsPlayer = playerTransform.position - animator.transform.position;
            towardsPlayer.y = 0;
            Vector3 newRotation = Vector3.RotateTowards(
                animator.transform.forward,
                towardsPlayer,
                rotationSpeed * Mathf.Deg2Rad * Time.deltaTime,
                1);
            animator.transform.rotation = Quaternion.LookRotation(newRotation);
        }
    }
}
