using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] float speed = 1.0f;
    Vector2 vector2;
    Vector2 moveInput;
    Vector2 lookInput;

    void Start()
    {
        
    }

    void OnMove (InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(direction * speed * Time.deltaTime);
        transform.Rotate(0, lookInput.x * 0.lf, 0);
        MainCamera.Rotate (-lookInput.y * 0.1f, 0, 0);
    }
}
