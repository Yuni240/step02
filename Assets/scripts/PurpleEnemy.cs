using UnityEngine;

public class PurpleEnemy : Enemy
{
    [SerializeField] private float speed;
    private float ShootTimer = 0;
    [SerializeField] private float ShootInterval;
    [SerializeField] private Transform LeftCanon;
    [SerializeField] private Transform RightCanon;

    [SerializeField] private GameObject BulletPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     rb.linearVelocity=Vector2.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
       ShootTimer += Time.deltaTime;
        if(ShootTimer > ShootInterval)
         {
              ShootTimer = 0;
              Instantiate(BulletPrefab, LeftCanon.position, Quaternion.identity);
              Instantiate(BulletPrefab, RightCanon.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerState>().PlayerTakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            //Destroy(collision.gameObject);
        }
    }
    public override void HurtSequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg"))
            return;
            anim.SetTrigger("Damage");
    }

    public override void DeathSequence()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        Destroy(gameObject);

    }
    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
