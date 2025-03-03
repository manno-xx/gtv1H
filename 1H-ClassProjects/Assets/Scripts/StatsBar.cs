using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A simple stats bar to show ... stats
/// Uses:
/// - UI.Image
/// - Gradient
/// </summary>
[RequireComponent(typeof(Image))]
public class StatsBar : MonoBehaviour
{
    private Image statsBar;

    [SerializeField] private Gradient colors;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        statsBar = GetComponent<Image>();
    }
    
    public void UpdateBar(float width)
    {
        // make sure that the image's
        // width is changed to match the incoming variable
        statsBar.fillAmount = width;
        statsBar.material.color = colors.Evaluate(width);

    }
}
