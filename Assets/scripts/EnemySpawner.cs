using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Camera mainCam;
    private float maxLeft;
    private float maxRight;
    private float yPosition;


    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject[] enemyPrefabs;
    private float enemyTimer;
    [Space(15)]
    [SerializeField] private float enemySpawnTime;
    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(SetBoundaries());
    }

    // Update is called once per frame
    void Update()
    {
       EnemySpawn();
    }

    private void EnemySpawn()
    {

        enemySpawnTime = Time.deltaTime;

        if (enemyTimer >= enemySpawnTime)
        {
            int randomPick = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomPick], new Vector3(Random.Range(maxLeft, maxRight), yPosition, 0), Quaternion.identity);
            enemyTimer = 0f;
        }
    }
        
    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(0.4f);
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        yPosition = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }
}
