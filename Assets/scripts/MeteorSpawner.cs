using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteorPrefab;
    [SerializeField] private float spawnTime;
    private float timer = 0f;
    private int i;
    private Camera mainCam;
    private float minLeft;
    private float maxRight;
    private float yPosition;
    [SerializeField] private float rotateSpeed;

    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(SetBoundaries());
    }

    void Update()
    {

        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            i = Random.Range(0, meteorPrefab.Length);
            GameObject spawnedMeteor = Instantiate(meteorPrefab[i], new Vector3(Random.Range(minLeft, maxRight), yPosition, -5), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            float size = Random.Range(0.9f, 1.1f);
            spawnedMeteor.transform.localScale = new Vector3(size, size, 1);
            timer = 0f;
        }
    }

    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(0.4f);
        minLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        yPosition = mainCam.ViewportToWorldPoint(new Vector2(0, 1)).y + 1f;
    }
}