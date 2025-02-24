using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A basic health system to slap onto objects that can receive damage
/// </summary>
public class Health : MonoBehaviour
{
    private float hp;
    [SerializeField] private float maxHP;

    public UnityEvent<float> hpUpdated;
    
    void Start()
    {
        hp = maxHP;
        hpUpdated.Invoke(hp / maxHP);
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
        hpUpdated.Invoke(hp / maxHP);
    }
}
