using System.Runtime.CompilerServices;
using UnityEngine;

public class ClickOpen : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (TryGetComponent(out Door door))
        {
            Debug.Log("Click to Open");
            door.Interact();
        }
    }
}
