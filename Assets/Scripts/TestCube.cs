using UnityEngine;

public class TestCube : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Rigidbody rigidbody;
    int hp = 3;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();
    }
    public void Action()
    {
        meshRenderer.material.color = new Color(Random.Range(0.0f,1.0f),
                                                Random.Range(0.0f,1.0f),
                                                Random.Range(0.0f,1.0f));

        rigidbody.AddForce(Vector3.up, ForceMode.Impulse);

        hp--;
        Debug.Log($"{gameObject.name} has {hp}");
    }
}
