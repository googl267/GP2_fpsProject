public class testInteract : Interactable
{
    public override void OnFocus()
    {
        print("Looking at " + gameObject.name);
    }

    public override void OnInteract()
    {
        print("Interacted with " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        print("Stopped looking at " + gameObject.name);
    }
}
