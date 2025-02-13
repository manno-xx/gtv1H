using UnityEngine;

/// <summary>
/// A basic health system to slap onto objects that can receive damage
/// </summary>
public class Health : MonoBehaviour
{
    private int hp;
    [SerializeField] private int maxHP;
    
    void Start()
    {
        hp = maxHP;
    }
    
    /// <summary>
    /// To be removed, just for quick testing
    /// </summary>
    private void OnMouseDown()
    {
        DoDamage(10);
    }
    
    /// <summary>
    /// Does damage to the hp system
    /// </summary>
    /// <param name="amount">the amount of damage to d</param>
    public void DoDamage(int amount)
    {
        hp -= amount;
        Debug.Log(hp);
    }
}
