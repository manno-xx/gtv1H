using System.Collections;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnSomething());
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnSomething()
    {
        // loops as long as the value in the parentheses is true
        while (true)
        {
            Instantiate(prefab);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
