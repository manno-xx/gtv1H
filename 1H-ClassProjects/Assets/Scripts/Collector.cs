using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Collects items that are stored in the list
/// Once the list is empty, all items are collected
/// </summary>
public class Collector : MonoBehaviour
{
    
    [SerializeField] private List<PickUp> itemsToCollect;
    
    /// <summary>
    /// checks if the things that is collided with has the PickUp component
    /// if so, it is removed 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // if player collides with an item that has the pickup component, call the PickUpItem 
        if (other.gameObject.TryGetComponent<PickUp>(out PickUp pickUp))
        {
            PickUpItem(pickUp);
        }
    }
    
    /// <summary>
    /// Pick up an item:
    /// - remove it from the list of items to pickup
    /// - destroy the game object
    /// - if the list is empty, do something
    /// game won
    /// </summary>
    /// <param name="pickUp">The </param>
    private void PickUpItem(PickUp pickUp)
    {
        itemsToCollect.Remove(pickUp);
        Destroy(pickUp.gameObject);
        if (itemsToCollect.Count == 0)
        {
            // do game over things
            Debug.Log("Game Over! All things have been collected");
        }
    }
}
