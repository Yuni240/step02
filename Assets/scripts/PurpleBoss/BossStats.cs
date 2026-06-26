using UnityEngine;
using UnityEngine.InputSystem;
public class BossStats : Enemy
{
    [SerializeField] private BossController bossController;
    public override void HurtSequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg")) // UPDATED: bracket moja ya ziada imeondolewa
            return;
        anim.SetTrigger("Damage");
    }
    public override void DeathSequence()
    {
        base.DeathSequence();
        bossController.ChangeState(BossState.death);
        Instantiate(explosionPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerState>().PlayerTakeDamage(damage); // UPDATED: semicolon imeongezwa
        }
    }

    // TEMPORARY DEBUG: bonyeza K kumuua boss moja kwa moja kwa testing
    // FUTA HII baada ya kumaliza kutest Win UI flow!
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            DeathSequence();
        }
    }
}