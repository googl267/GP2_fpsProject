using System.Collections;

public class ORB_Item : Item
{
    private void OnEnable()
    {
        ID = 1;
        Title = "ORB";
        Weight = 15f;
        Stackable = false;        
    }
}
