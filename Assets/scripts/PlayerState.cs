using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Animator Anim;


    private float health;
    private bool canPlayAnim=true;

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

        if (canPlayAnim)
        {
            Anim.SetTrigger("Damage");
            StartCoroutine(AntiSpamAnimation());

        }
        
        if (health<=0)
        {

            EndGameManager.endManager.gameOver=true;
            EndGameManager.endManager.StartResolveSequence();
           
            Instantiate(explosionPrefab, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
    private IEnumerator AntiSpamAnimation()
    {
        canPlayAnim=false;
        yield return new WaitForSeconds(0.15f);
        canPlayAnim=true;
    }
}
