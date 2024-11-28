using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    private InputAction lookAction;
    private GameObject cameraPosition3;   // 3rd person view
    private GameObject character;
    private Vector3 c;
    private Vector3 cameraAngles, cameraAngles0;
    private bool isFpv;
    private float sensitivityH = 0.05f;
    private float sensitivityV = -0.025f;

    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
        character = GameObject.Find("Character");
        c = this.transform.position - character.transform.position;
        cameraPosition3 = GameObject.Find("CameraPosition");
        cameraAngles0 = cameraAngles = this.transform.eulerAngles;
        isFpv = true;
    }

    void Update()
    {
        if(Time.timeScale == 0.0f) return; 

        if (isFpv)
        {
            float wheel = Input.mouseScrollDelta.y;
            c *= 1 - wheel / 10.0f;
            // Д.З. ч.1 Обмежити діапазон змін відстані камери від персонажу
            // як з боку великих значень (доки поле не буди видно повністю)
            // так і з боку малих значень (камера в середині персонажа)
            // * Реалізувати різкий перехід у діапазоні, коли камера близька
            //   до персонажа і він перекриває велику частину поля зору.

            GameState.isFpv = c.magnitude < 0.25f;

            Vector2 lookValue = lookAction.ReadValue<Vector2>();
            cameraAngles.x += lookValue.y * sensitivityV;
            cameraAngles.y += lookValue.x * sensitivityH;
            this.transform.eulerAngles = cameraAngles;

            this.transform.position = character.transform.position + 
                Quaternion.Euler(0, cameraAngles.y - cameraAngles0.y, 0) * c;
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
/* Д.З. ч.2 Підібрати текстури для неба (Skybox), випробувати їх
 * Розмістити по ігровому полю декілька джерел точкового світла,
 * підібрати для них "оточення" зі світними матеріалами.
 */
