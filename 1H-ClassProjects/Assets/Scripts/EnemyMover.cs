using UnityEngine;

/// <summary>
/// 
/// </summary>
public class EnemyMover : MonoBehaviour
{
    // pick a random position
    private Vector3 randomPosition;
    
    void Start()
    {
        randomPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }

    // move towards the chosen position
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            randomPosition,
            2 * Time.deltaTime);

        // if we are very neAR THE destination, destroy this
        if (Vector3.Distance(transform.position, randomPosition) <= .1f)
        {
            Destroy(gameObject);
        }
    }
}
