using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    private InputAction lookAction;
    private GameObject cameraPosition3;   // 3rd person view
    private GameObject character;
    private Vector3 c;
    private Vector3 cameraAngles;
    private bool isFpv;
    private float sensitivityH = 0.05f;
    private float sensitivityV = -0.025f;

    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
        character = GameObject.Find("Character");
        c = this.transform.position - character.transform.position;
        cameraPosition3 = GameObject.Find("CameraPosition");
        cameraAngles = this.transform.eulerAngles;
        isFpv = true;
    }

    void Update()
    {
        if (isFpv)
        {
            Vector2 lookValue = lookAction.ReadValue<Vector2>();
            cameraAngles.x += lookValue.y * sensitivityV;
            cameraAngles.y += lookValue.x * sensitivityH;
            this.transform.eulerAngles = cameraAngles;

            this.transform.position = character.transform.position + 
                Quaternion.Euler(0, cameraAngles.y, 0) * c;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isFpv)
            {
                this.transform.position = cameraPosition3.transform.position;
                this.transform.rotation = cameraPosition3.transform.rotation;
            }
            isFpv = !isFpv;
        }
    }
}
