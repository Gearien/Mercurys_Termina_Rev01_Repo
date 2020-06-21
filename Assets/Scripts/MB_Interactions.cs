using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_Interactions : MonoBehaviour

{
    public bool hasDetectionObjetcMaterial = true;
    public bool hasInteractionObjectMaterial = true;

    public Material detectionObjectMaterial;
    public Material interactionObjectMaterial;
    public Material initialObjectMaterial;

    private bool isInteractionOnGoing = false;
    private bool isDetectionOnGoing = false;


    void Start()
    {
       initialObjectMaterial = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        if((isDetectionOnGoing == true) && (hasDetectionObjetcMaterial == true))
        {
            GetComponent<MeshRenderer>().material = detectionObjectMaterial;
        }
        else if((isInteractionOnGoing == true) && (hasInteractionObjectMaterial == true))
        {
            GetComponent<MeshRenderer>().material = interactionObjectMaterial;
        }
        else if((isInteractionOnGoing == false) && (isDetectionOnGoing== false))
        {
            GetComponent<MeshRenderer>().material = initialObjectMaterial;
        }

        isDetectionOnGoing = false;
        
    }

    public virtual void Detection()
    {
        print("Detection");
        isDetectionOnGoing = true;
    }

    public virtual void Interact()
    {
        print("Interact");
        isInteractionOnGoing = true;
    }

    public virtual void StopInteract()
    {
        print("Stop Interact");
        isInteractionOnGoing = false;
    }
}
