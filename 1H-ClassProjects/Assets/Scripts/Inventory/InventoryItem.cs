using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private int itemCount;

    private Inventory inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = GameObject.FindFirstObjectByType<Inventory>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventory.AddToInventory(itemType, itemCount);
            
            SendMessage("TriggerSound", SendMessageOptions.DontRequireReceiver);
            
            Destroy(gameObject);
        }
    }
}
