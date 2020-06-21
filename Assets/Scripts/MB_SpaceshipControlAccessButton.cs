using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_SpaceshipControlAccessButton : MB_Interactions
{
    private float nbInteract = 0;

    public override void Interact()
    {
        base.Interact();
        Action();
    }

    void Action()
    {
        nbInteract += 1;

        if(nbInteract == 1)
        {
            SpaceshipController isInSpaceshipControlMode = GetComponent<SpaceshipController>();
            isInSpaceshipControlMode.SpaceshipStart();

            CameraController lockedSpaceshipControlCamera = GetComponent<CameraController>();
            lockedSpaceshipControlCamera.LockedSpaceshipControlCamera();

            //SpaceshipController.spaceshipInstance.SpaceshipStart();
            //CameraController.cameraInstance.LockedSpaceshipControlCamera();
        }

        if (nbInteract >=2)
        {
            MB_Interactions isInteract = GetComponent<MB_Interactions>();
            isInteract.StopInteract();

            nbInteract = 0;
        }
    }

}
