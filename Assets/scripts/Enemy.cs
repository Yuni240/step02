using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] protected float Health;
    [SerializeField] protected  Rigidbody2D rb;
    [SerializeField] protected float damage;
    [SerializeField] protected GameObject explosionPrefab;
    [SerializeField] protected Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float dmg)
    {
        Health -= dmg;

        //damage animation 
        HurtSequence();
        if (Health <= 0)
        {
            //destoy animation
            DeathSequence();
        }
    }
    public virtual void HurtSequence()
    {
        //do smth
    }
    public virtual void DeathSequence()
    {
        //destoy animation
       
    }
}
