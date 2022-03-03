using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] horsePrefabs;
    
    private float startDelay = 2f;
    private float repeatRate = 1.8f;
    private float spawnPosX = 15;
    private float spawnPosZ = -90;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnHorses", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnHorses()
    {


        int animalIndex = Random.Range(0, horsePrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosX), 0,spawnPosZ);

        Instantiate(horsePrefabs[animalIndex], spawnPos, horsePrefabs[animalIndex].transform.rotation);


    }
}
