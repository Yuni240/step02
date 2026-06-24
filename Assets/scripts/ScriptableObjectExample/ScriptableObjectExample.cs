using UnityEngine;


[CreateAssetMenu(menuName ="SriptableObject/PowerUpSpawner" ,fileName ="Spawner")]
public class ScriptableObjectExample : ScriptableObject
{
    public GameObject[] powerUp;


    public void spawnPowerUp(Vector3 spawnPos)
    {

        int randomPowerUp= Random.Range(0, powerUp.Length);
        Instantiate(powerUp[randomPowerUp], spawnPos ,Quaternion.identity);
    }






}

