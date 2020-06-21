using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour

{
    //public static SpaceshipController spaceshipInstance;

    public Rigidbody spaceshipController;
    public float speed = 10f;

    public bool isInSpaceshipControlMode = false;

    // Start is called before the first frame update
    void Start()
    {
        /*
        if(spaceshipInstance != this)
        {
            Destroy(this);
        }
        else
        {
            spaceshipInstance = this;
        }
        */

        spaceshipController = this.GetComponent<Rigidbody>();

    }

    public virtual void SpaceshipStart()
    {
        print("Spaceship Start");
        isInSpaceshipControlMode = true;
    }

    void Update()
    {
        if(GameInputManager.GetKey("MoveForward"))
        {
            print("Touche Enfoncée");
        }
        else
        {
            print("Touche Pas Enfoncée");
        }
    }


    private void FixedUpdate()
    {
        SpaceshipMovement();
    }

    // Update is called once per frame
    void SpaceshipMovement()
    {
        if(isInSpaceshipControlMode == true)
        {
            //DEPLACEMENTS 
            if (GameInputManager.GetKey("MoveForward"))
            {
                spaceshipController.AddForce(transform.forward * speed * Time.deltaTime);
                print("MoveForward");
            }

            if (GameInputManager.GetKey("MoveBackward"))
            {
                spaceshipController.AddForce(-transform.forward * speed * Time.deltaTime);
            }

            if (GameInputManager.GetKey("MoveRight"))
            {
                spaceshipController.AddForce(transform.right * speed * Time.deltaTime);
            }

            if (GameInputManager.GetKey("MoveLeft"))
            {
                spaceshipController.AddForce(-transform.right * speed * Time.deltaTime);
            }

            if (GameInputManager.GetKey("MoveUp"))
            {
                spaceshipController.AddForce(transform.up * speed * Time.deltaTime);
            }

            if (GameInputManager.GetKey("MoveDown"))
            {
                spaceshipController.AddForce(-transform.up * speed * Time.deltaTime);
            }

            //ROTATIONS
            if (GameInputManager.GetKey("YawL"))
            {

            }

        }
    }
}
