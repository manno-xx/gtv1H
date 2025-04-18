using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Simple movement script to be able to walk through test levels
/// Move forward/backwards with W/S
/// Turn left/right with A/D
/// Requires a Rigidbody to work
/// Credit: Gerard van der Lei
/// Modified to use 'new input system': Manno
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class MovementWithPhysics : MonoBehaviour
{
	/// <summary>
	/// The speed of the movement of the player.
	/// </summary>
	[SerializeField]
	private float _movementSpeed = 1;

	/// <summary>
	/// Speed of turning in Degrees per second.
	/// </summary>
	[SerializeField]
	private float _turningSpeed = 1;

	/// <summary>
	/// Stores the movement input between Update and FixedUpdate
	/// </summary>
	private float _inputMovement;
	/// <summary>
	/// Stores the turning input between Update and FixedUpdate
	/// </summary>
	private float _inputTurning;

	/// <summary>
	/// Reference to Rigidbody.
	/// </summary>
	private Rigidbody _body;

	private InputAction _move;

	/// <summary>
	/// Start function is called once at the beginning
	/// Used to get reference to Rigidbody so we can store for later use
	/// </summary>
	private void Start()
	{
		_body = GetComponent<Rigidbody>();
		_move = InputSystem.actions.FindAction("Move");
	}

	/// <summary>
	/// Update is used to get Input from the player
	/// Input must always be gotten in the Update Method, otherwise you might experience unpredictable behaviour
	/// </summary>
	private void Update()
	{
		Vector2 input = _move.ReadValue<Vector2>();
		_inputMovement = input.y * _movementSpeed;
		_inputTurning = input.x * _turningSpeed;
	}

	/// <summary>
	/// Apply physics in FixedUpdate.
	/// All updates to Physics must be done in FixedUpdate, otherwise you might experience unpredictable behaviour
	/// </summary>
	private void FixedUpdate()
	{
		Turn();
		Move();
	}
	
	/// <summary>
	/// Turn the Rigidbody.
	/// </summary>
	private void Turn()
	{
		// Set the angularVelocity around the y-axis to the desired turning speed.
		// Angular velocity is in Radians, and our setting is in Degrees, so we need to convert those units.
		Vector3 angularVelocity = _body.angularVelocity;
		angularVelocity.y = _inputTurning * Mathf.Deg2Rad;
		_body.angularVelocity = new Vector3(0, angularVelocity.y, 0);
	}

	/// <summary>
	/// Move the Rigidbody.
	/// </summary>
	private void Move()
	{
		// Get our target velocity, which is a sum of the player input and the current vertical velocity (due to falling or jumping)
		Vector3 targetVelocity = transform.forward * _inputMovement;// + Vector3.up * _body.linearVelocity.y;
		// Calculate difference between our target velocity and our current velocity
		Vector3 deltaVelocity = targetVelocity - _body.linearVelocity;
		// Add the difference in velocity to the Rigidbody as a VelocityChange
		// This get an immediate response, which works well for controlled character
		_body.AddForce(deltaVelocity, ForceMode.VelocityChange);
	}
}