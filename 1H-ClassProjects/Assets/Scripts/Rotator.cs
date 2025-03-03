using UnityEngine;

/// <summary>
/// Simply rotates the game object this script is on all three axis 
/// </summary>
public class Rotator : MonoBehaviour
{
    [SerializeField, Tooltip("rotation speed in degrees per second")] private float rotationSpeed = 10;
    
    void Update()
    {
        var degrees = rotationSpeed * Time.deltaTime;
        transform.Rotate(degrees, degrees, degrees);
    }
}
