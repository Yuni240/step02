using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] protected float Health;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float damage;
    [SerializeField] protected GameObject explosionPrefab;
    [SerializeField] protected Animator anim;
    [Header("Score"), SerializeField]
    protected int scoreValue;
    [SerializeField] protected ScriptableObjectExample powerUpSpawner; // UPDATED: powerup spawner

    public void TakeDamage(float dmg)
    {
        Health -= dmg;
        Debug.Log(gameObject.name + " amepokea damage: " + dmg + " | Health sasa: " + Health); // ONGEZA HII
        HurtSequence();
        if (Health <= 0)
        {
            DeathSequence();
        }
    }

    public virtual void HurtSequence()
    {
        //do smth
    }

    public virtual void DeathSequence()
    {
        EndGameManager.endManager.UpdateScore(scoreValue);
        // UPDATED: spawn powerup pale enemy anapofa
        if (powerUpSpawner != null)
            powerUpSpawner.spawnPowerUp(transform.position);
    }
}