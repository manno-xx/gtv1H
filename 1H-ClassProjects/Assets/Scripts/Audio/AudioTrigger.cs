using UnityEngine;
using UnityEngine.Events;

public class AudioTrigger : MonoBehaviour
{
    public UnityEvent onPlaySound;

    public void TriggerSound()
    {
        onPlaySound?.Invoke();
    }
}

