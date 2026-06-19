using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] int hp = 3;
    [SerializeField] TMP_Text hpLabel;
    void Start()
    {
        hpLabel.text = hp.ToString();
    }

    public void OnTakeDamage(int damage = 1)
    {
        hp -= damage;
        if (hp <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        hpLabel.text = hp.ToString();
    }
}
