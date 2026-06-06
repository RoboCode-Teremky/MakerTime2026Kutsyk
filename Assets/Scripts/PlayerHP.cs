using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] int hp = 3;
    void Start()
    {

    }

    public void OnTakeDamage(int damage = 1)
    {
        hp-=damage;
        if(hp<=0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
