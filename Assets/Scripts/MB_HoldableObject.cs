using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_HoldableObject : MB_Interactions
{
    public override void Interact()
    {
        base.Interact();
        Action();
    }

    void Action()
    {
        print("Holdable Object Hold");

        this.transform.position = GetComponent<CameraController>().Target.transform.position;

        if(GameInputManager.GetKeyDown("EndHold"))
        {
            MB_Interactions isInteract = GetComponent<MB_Interactions>();
            isInteract.StopInteract();
        }
    }
}
