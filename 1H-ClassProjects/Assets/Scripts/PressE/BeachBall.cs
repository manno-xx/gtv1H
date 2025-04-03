using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// A beach ball to kick around a little
/// Implements the IInteractable interface to be able to address it in a uniform way
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class BeachBall : MonoBehaviour, IInteractable
{
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    /// <summary>
    /// When interacting: Kick the ball upwards with a small offset
    /// </summary>
    public void Interact()
    {
        Vector3 direction = Quaternion.AngleAxis(Random.Range(-10f, 10f), Vector3.forward) * Vector3.up * 20;
        
        rb.AddForce(direction, ForceMode.VelocityChange);
    }
}


