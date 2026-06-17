using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosionPrefab;


    private float health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       health=maxHealth;
        healthFill.fillAmount=health/maxHealth;
    }

    // Update is called once per frame
    public void PlayerTakeDamage(float damage)
    {
        health-=damage;
        healthFill.fillAmount=health/maxHealth;
        if (health<=0)
        {
            health=0;
            Destroy(gameObject);
        }
    }
}
