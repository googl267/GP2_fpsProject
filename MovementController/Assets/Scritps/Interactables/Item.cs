public class Item : Interactable
{
    public float weight { get; private set; } = 10f;

    public override void OnFocus()
    {
        print("Looking at " + gameObject.name);
    }

    public override void OnInteract()
    {
        InventoryController.OnPickedUpAttempt(this);
    }

    public override void OnLoseFocus()
    {
        print("Stopped looking at " + gameObject.name);
    }
}
