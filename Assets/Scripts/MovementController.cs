using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float gravity = 9.8f;
    [SerializeField] float jumpForce = 10.0f;
    float verticalSpeed = 0.0f;
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
        if (characterController.isGrounded && verticalSpeed < 0.0f)
        {
            verticalSpeed = -1.0f;
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }

        Vector3 move = (transform.forward * direction.y
                        + transform.right * direction.x) * speed
                        + transform.up * verticalSpeed;
        characterController.Move(move * Time.deltaTime);
    }
}