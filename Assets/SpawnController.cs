using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<GameObject> fishes;
    [SerializeField] private float timeToNextSpawn = 1;
    [SerializeField] private int maxAmountOfFishes = 5;
    private int currentAmountOfFishes = 0;
    private float maxTimeToSpawn;


    private void Start()
    {
        maxTimeToSpawn = timeToNextSpawn;
    }


    private void Update() 
    {
        if(currentAmountOfFishes > maxAmountOfFishes)
            return;

        if(timeToNextSpawn <= 0.0f)
            SpawnRandomFish();
        else
            timeToNextSpawn -= Time.deltaTime;
    }

    private void SpawnRandomFish()
    {
        GameObject randomizedFish = RandomizeFish();
        Transform randomizedPoint = RandomizePoint();
        Instantiate(randomizedFish, randomizedPoint.position, Quaternion.identity);
        timeToNextSpawn = maxTimeToSpawn;
        currentAmountOfFishes++;
    }

    private GameObject RandomizeFish()
    {
        return fishes[Random.Range(0, fishes.Count)];
    }

    private Transform RandomizePoint()
    {
        return transform.GetChild(Random.Range(0, transform.childCount - 1));
    }
}
