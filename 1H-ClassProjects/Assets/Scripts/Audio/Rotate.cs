using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float RotationSpeed = -10;
    
    void Update()
    {
        transform.Rotate(0, RotationSpeed * Time.deltaTime, 0, Space.World);
    }
}
