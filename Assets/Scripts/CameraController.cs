using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1.0f;
    Vector2 direction;

    public void OnLook(InputAction.CallbackContext callbackContext)
    {
        direction  = callbackContext.ReadValue<Vector2>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    float xCameraAngle = 0.0f;
    void Update()
    {
        transform.Rotate(
            new Vector3(0.0f,
                        direction.x*rotationSpeed*Time.deltaTime,
                        0.0f));

        xCameraAngle -= direction.y*rotationSpeed*Time.deltaTime;
        xCameraAngle = Mathf.Clamp(xCameraAngle, -80.0f, 80.0f);
        Camera.main.transform.localEulerAngles = new Vector3(xCameraAngle, 0.0f, 0.0f);
    }
}
