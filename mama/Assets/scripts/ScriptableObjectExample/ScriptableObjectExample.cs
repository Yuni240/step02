using UnityEngine;


[CreateAssetMenu(menuName ="SriptableObject/PowerUpSpawner" ,fileName ="Spawner")]
public class ScriptableObjectExample : ScriptableObject
{
    public int spawnThreshold;
    public GameObject[] powerUp;


    public void spawnPowerUp(Vector3 spawnPos)
    {
        int randomChance = Random.Range(0, 100);

        if (randomChance > spawnThreshold)
        {

            int randomPowerUp = Random.Range(0, powerUp.Length);
            Instantiate(powerUp[randomPowerUp], spawnPos, Quaternion.identity);
        }
    }






}

