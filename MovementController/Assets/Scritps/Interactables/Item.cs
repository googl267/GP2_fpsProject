public class Item : Interactable
{
    public int ID { get; protected set; } = 3;
    public int Type { get; protected set; } = 0;
    public string Title { get; protected set; } = "Item";
    public float Weight { get; protected set; } = 10f;
    public int Count { get; protected set; } = 1;

    public override void OnFocus()
    {
        //print("Looking at " + gameObject.name);
    }

    public override void OnInteract()
    {
        FirstPersonController.OnPickedUpAttempt(this);
    }

    public override void OnLoseFocus()
    {
        //print("Stopped looking at " + gameObject.name);
    }
}
