using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
        public virtual void Awake() {
                gameObject.layer = 6;  // number is the layer index for interactables
        }

        public abstract void OnInteract();
        public abstract void OnFocus();
        public abstract void OnLoseFocus();
}