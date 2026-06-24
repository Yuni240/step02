using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBulletPrefab;
    [SerializeField] private Transform basicShootingPoint;
    [SerializeField] private float shootingInterval;
    private float intervalReset;    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        intervalReset = shootingInterval;

    }

    // Update is called once per frame
    void Update()
    {
      shootingInterval -= Time.deltaTime;
        if (shootingInterval<=0)
        {
            shoot();
            shootingInterval = intervalReset;
        }
    }
    private void shoot()
    {
        Instantiate(laserBulletPrefab, basicShootingPoint.position, Quaternion.identity);
    }
}
