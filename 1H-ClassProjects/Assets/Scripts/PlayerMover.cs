using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Moves a player character using RigidBody and forces
/// Uses the 'new input system'
/// Input is read every frame (in Update)
/// Forces are applied to the rigid body every PHYSICS frame (in FixedUpdate)
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    // both speeds (movement and rotation) are set in the inspector
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float turnSpeed = 45;
    
    // these will store the input from the player combined with the move and rotation speed
    private float moveInput;
    private float turnInput;

    // the reference to the Input action in the Action Map
    private InputAction moveAction;

    // The rigid Body to apply the forces to
    private Rigidbody rigidBody;
    
    /// <summary>
    /// loop up the 'Move' InputAction in the mapping
    /// </summary>
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rigidBody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        moveInput = input.y * moveSpeed;
        turnInput = input.x * turnSpeed;
    }

    private void FixedUpdate()
    {
        DoTurn();
        DoMove();
    }
    
    /// <summary>
    /// Target velocity: Combination of the force based on input from the player with the vertical force based on gravity
    /// delta velocity is the difference between current/actual velocity and the desired velocity
    /// The force is then applied in the direction of delta velocity
    /// </summary>
    private void DoMove()
    {
        Vector3 targetVelocity = transform.forward * moveInput + Vector3.up * rigidBody.linearVelocity.y;
        Vector3 deltaVelocity = targetVelocity - rigidBody.linearVelocity;
        rigidBody.AddForce(deltaVelocity, ForceMode.VelocityChange);
    }

    /// <summary>
    /// Here the y-direction of the angular velocity is set based on the input from the player
    /// </summary>
    private void DoTurn()
    {
        Vector3 av = rigidBody.angularVelocity;
        av.y = turnInput * Mathf.Deg2Rad;
        rigidBody.angularVelocity = av;
    }
}