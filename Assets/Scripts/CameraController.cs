using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform pivot;
    public float mouseSensitivity = 100f;
    public float clampValue = 85f;

    float xRotation = 0f;
    float yRotation = 0f;

    private Camera PlayerCamera;
    Cinemachine.CinemachineVirtualCamera c_VirtualCamera;

    public GameObject Target;
    public GameObject SpaceshipControlTarget;
    private Vector3 cameraCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

    //public static CameraController cameraInstance;
    public bool isInSpaceshipControlMode = false;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PlayerCamera = Camera.main;
        //c_VirtualCamera = PlayerCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>();

        /*
        if (cameraInstance != this)
        {
            Destroy(this);
        }
        else
        {
            cameraInstance = this;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        //PRINT DEBUG
        print(isInSpaceshipControlMode);

        //CameraZoom();

        // CAMÉRA EN MODE COCKPIT
        if(isInSpaceshipControlMode == false)
        {
            UpdateFollowMouseCamera();
            InteractionDetection();
            InteractionActivation();
        }
        
    }

    // SYSTEME DE CAMERA VUE FPS
    void UpdateFollowMouseCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -clampValue, clampValue);

        yRotation -= mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);

    }

    // DETECTION D'OBJETS AVEC INTERACTIONS POSSIBLES 
    void InteractionDetection()
    {
        RaycastHit detect;
        Ray ray = PlayerCamera.ScreenPointToRay(cameraCenter);

        if (Physics.Raycast(ray, out detect, 10000, LayerMask.GetMask("Interactions")))
        {
            print("Ray Detect");
            MB_Interactions detection = detect.collider.GetComponent<MB_Interactions>();
            detection.Detection();
        }
    }

    // ACTIVATION D'OBJETS AVEC INTERACTIONS
    void InteractionActivation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction);

            if (Physics.Raycast(ray, out hit, 10000, LayerMask.GetMask("Interactions")))
            {
                MB_Interactions interactions = hit.collider.GetComponent<MB_Interactions>();
                if (interactions != null)
                {
                    interactions.Interact();
                }
            }
        }

    }

    // BLOCAGE DE LA CAMÉRA LIBRE DU COCKPIT EN MODE PILOTAGE DU VAISSEAU
    
    public virtual void LockedSpaceshipControlCamera()
    {
        print("Spaceship Control Mode");
        isInSpaceshipControlMode = true;
        c_VirtualCamera.m_LookAt = SpaceshipControlTarget.transform;
    }
    
    /*
    void CameraZoom()
    {
        if (GameInputManager.GetKeyDown("CameraZoom"))
        {
           // c_VirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance;
        }
    }
    */
}
