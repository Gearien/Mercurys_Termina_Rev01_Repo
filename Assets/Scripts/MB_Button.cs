using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_Button : MB_Interactions
{
    public override void Interact()
    {
        base.Interact();
        Action();
    }

    void Action()
    {
        print("Button Action");

        MB_Interactions isInteract= GetComponent<MB_Interactions>();
        isInteract.StopInteract();
    }
}
