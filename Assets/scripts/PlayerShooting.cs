using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBulletPrefab;
    [SerializeField] private float shootingInterval;

   

    [Header("Basic attack")]
   
    [SerializeField] private Transform basicShootingPoint;
    [Header("Upgrade Point")]
    [SerializeField] private Transform leftCanon;
    [SerializeField] private Transform rightCanon;
    [SerializeField] private Transform secondLeftCanon;
    [SerializeField] private Transform secondRightCanon;

    [Header("Upgrade rotation Points")]
    [SerializeField] private Transform leftRotationCanon;
    [SerializeField] private Transform rightRotationCanon;
    [SerializeField] private AudioSource source;

    private int upgradeLevel = 0;  



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

    public void IncreaseUpgrade(int increaseAmount)
    {
        upgradeLevel += increaseAmount;
        if (upgradeLevel > 4)

            upgradeLevel = 4;
    }

    public void DecreaseUpgrade()
    {
        upgradeLevel -= 1;
        if (upgradeLevel < 0)  
            upgradeLevel = 0;
    }
    private void shoot()
    {
        source.Play();
        // Instantiate(laserBulletPrefab, basicShootingPoint.position, Quaternion.identity);
        switch (upgradeLevel)
        {
            case 0:
             Instantiate(laserBulletPrefab, basicShootingPoint.position, Quaternion.identity);
                break;

                case 1:
                 Instantiate(laserBulletPrefab, leftCanon.position, Quaternion.identity);
                 Instantiate(laserBulletPrefab, rightCanon.position, Quaternion.identity);
                break;
            case 2:
                 Instantiate(laserBulletPrefab, basicShootingPoint.position, Quaternion.identity);
                 Instantiate(laserBulletPrefab, leftCanon.position, Quaternion.identity);
                 Instantiate(laserBulletPrefab, rightCanon.position, Quaternion.identity);
                break;
                case 3:
                Instantiate(laserBulletPrefab, basicShootingPoint.position, Quaternion.identity);
                Instantiate(laserBulletPrefab, leftCanon.position, Quaternion.identity);
                Instantiate(laserBulletPrefab, rightCanon.position, Quaternion.identity);
                Instantiate(laserBulletPrefab, secondLeftCanon.position, Quaternion.identity);
                Instantiate(laserBulletPrefab, secondRightCanon.position, Quaternion.identity);
                break;
                case 4:
                Instantiate(laserBulletPrefab, basicShootingPoint.position, Quaternion.identity);
                Instantiate(laserBulletPrefab, leftCanon.position, Quaternion.identity);
                Instantiate(laserBulletPrefab, rightCanon.position, Quaternion.identity);
                Instantiate(laserBulletPrefab, secondLeftCanon.position, Quaternion.identity);
                Instantiate(laserBulletPrefab, secondRightCanon.position, Quaternion.identity);
                Instantiate(laserBulletPrefab, leftRotationCanon.position, leftRotationCanon.rotation);
                Instantiate(laserBulletPrefab, rightRotationCanon.position, rightRotationCanon.rotation);
                break;

                default:
                break;






        }
    }
}
