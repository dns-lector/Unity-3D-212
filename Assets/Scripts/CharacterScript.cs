using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterScript : MonoBehaviour
{
    private Rigidbody rb;
    private InputAction moveAction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        rb.AddForce(Time.deltaTime * 300 * 
            // new Vector3(moveValue.x, 0, moveValue.y)
            (
                moveValue.x * Camera.main.transform.right +
                moveValue.y * Camera.main.transform.forward
            )
        );
    }
}
