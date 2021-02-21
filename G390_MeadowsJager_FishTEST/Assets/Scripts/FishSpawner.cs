using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    //public variables
    public int fishSpawned;
    public float spawnTime;

    //private variables
    private Vector3 Min;
    private Vector3 Max;
    private float _xAxis;
    private float _yAxis;
    private float _zAxis; 
    private Vector3 _randomPosition;

    //fish variables
    [SerializeField] private List<Transform> fishList;


    //runs at the start of the application
    private void Awake()
    {
        //spawns a new fish every few seconds
        InvokeRepeating("SpawnFish", spawnTime, spawnTime);

        //sets area for fish
        SetRanges();
    }

    //runs every frame
    private void Update()
    {
        //if not enough fish, spawn more fish
        if (fishSpawned <= 8)
        {
            //Spawn another fish
            SpawnFish();
        }

        //randomizes every frame the axis points for possible spawning
        _xAxis = UnityEngine.Random.Range(Min.x, Max.x);
        _yAxis = UnityEngine.Random.Range(Min.y, Max.y);
        _zAxis = UnityEngine.Random.Range(Min.z, Max.z);
        _randomPosition = new Vector3(_xAxis, _yAxis, _zAxis);
    }

    //this is where you put the range for the spawn area
    private void SetRanges()
    {
        Min = new Vector3(8, 1, -4); 
        Max = new Vector3(16, 1, 4); 
    }

    //spawns random fish from list at random area
    private void SpawnFish()
    {
        Transform chosenFish;
        // select fish
        chosenFish = fishList[Random.Range(0, fishList.Count)];

        //spawns the fish
        Instantiate(chosenFish, _randomPosition, Quaternion.identity);

        fishSpawned++;
        Debug.Log(fishSpawned);
    }
}
