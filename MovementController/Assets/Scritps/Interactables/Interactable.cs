using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public virtual void Awake()
    {
        gameObject.layer = 6; // number is the layer index for interactables - should be the same as player controllres interactable layer
    }

    public abstract void OnInteract();
    public abstract void OnFocus();
    public abstract void OnLoseFocus();
}
