using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Spawns a number of items at start using a loop
/// </summary>
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;

    [SerializeField] private List<GameObject> enemies;
    
    [SerializeField] private int amount = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector2 rnd = Random.insideUnitCircle;          // let Unity create a 2D position
            Vector3 pos = new Vector3(rnd.x, 0, rnd.y);     // 'rotate' the position over the x-axis
            GameObject go = Instantiate(obstacle, pos * 10, Quaternion.identity);
            
            enemies.Add(go);
        }
    }

    /// <summary>
    /// nonsense functionality, but just to show loops over lists: Move every item to a random y-position every frame
    /// </summary>
    void Update()
    {
        foreach (var enemy in enemies)
        {
            // do something with the gameobject
            Vector3 pos = enemy.transform.position;
            pos.y = Random.Range(0, 10);
            enemy.transform.position = pos;
        } 
    }
}
