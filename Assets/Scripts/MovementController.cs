using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController: MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    Vector2 direction;
    CharacterController characterController;

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        direction = callbackContext.ReadValue<Vector2>();
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = transform.forward*direction.y
                        + transform.right*direction.x;
        characterController.Move(move*speed*Time.deltaTime);
    }
}