using System.Collections;
using UnityEngine;
public class BossFire : BossBaseState
{
    [SerializeField] private float speed;
    [SerializeField] private float shootRate;
    [SerializeField] private GameObject[] bulletPrefab;
    [Header("Shooting Points")]
    [SerializeField] private Transform[] shootPoint;

    public override void RunState()
    {
        StartCoroutine(RunFireState());
    }

    public override void StopState()
    {
        base.StopState();
    }

    IEnumerator RunFireState()
    {
        float shootTimer = 0f;
        float fireStateTimer = 0f;
        float fireStateExitTime = Random.Range(5f, 10f);
        Vector2 targetPosition = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxDown, maxUp));

        while (fireStateTimer <= fireStateExitTime)
        {
            if (Vector2.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            else
            {
                targetPosition = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxDown, maxUp));
            }

            shootTimer += Time.deltaTime;
            if (shootTimer >= shootRate)
            {
                shootTimer = 0; // UPDATED: reset kwanza kabla ya shoot
                for (int i = 0; i < shootPoint.Length; i++)
                {
                    int bulletIndex = Random.Range(0, bulletPrefab.Length);
                    Instantiate(bulletPrefab[bulletIndex], shootPoint[i].position, shootPoint[i].rotation); // UPDATED: tumia rotation ya shootPoint
                }
            }

            yield return new WaitForEndOfFrame();
            fireStateTimer += Time.deltaTime;
        }

        bossController.ChangeState(BossState.special);
    }
}