using UnityEngine;
using System;

public class InventoryController : MonoBehaviour
{
    [Header("Inventory Properties")]
    [SerializeField] private float maxWeight = 50;
    private float currentWeight = 0;
    public static Action<Item> OnPickedUpAttempt;

    private void OnEnable() {
        OnPickedUpAttempt += AttemptPickUp;
    }

    private void OnDisable() {
        OnPickedUpAttempt -= AttemptPickUp;
    }

    public void AttemptPickUp(Item itemRef) {
        if (currentWeight + itemRef.weight > maxWeight)
            return;

        currentWeight += itemRef.weight;
        Destroy(itemRef.gameObject);
        print("PICKED UP ITEM");
    }
}