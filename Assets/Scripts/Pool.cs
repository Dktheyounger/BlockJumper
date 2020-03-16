using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField]
    private int PoolSize = 5;
    [SerializeField]
    private GameObject Prefab;
    [SerializeField]
    private float spawnRate = 4f;

    //Y
    [SerializeField]
    private float MinY = -1f;
    [SerializeField]
    private float MaxY = 3.5f;

    //Z 
    [SerializeField]
    private float MinZ = -1f;
    [SerializeField]
    private float MaxZ = 3.5f;

    //X
    [SerializeField]
    private float MinX = -1f;
    [SerializeField]
    private float MaxX = 3.5f;

    [SerializeField]
    private float yChange;

    [SerializeField]
    private AudioSource audioData;


    private GameObject[] PoolMembers;
    private Vector3 objectPoolPosition = new Vector3(-100f, -100f, -100f);
    private float timeSinceLastSpawned;

    private int currentPoolMemeber = 0;


    void Start()
    {
        audioData = GetComponent<AudioSource>();
        PoolMembers = new GameObject[PoolSize];

        for (int i = 0; i < PoolSize; i++)
        {
            PoolMembers[i] = (GameObject)Instantiate(Prefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        MinY += yChange;
        MaxY += yChange;

        if (timeSinceLastSpawned >= spawnRate)
        {
            audioData.Play(0);
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(MinY, MaxY);
            float spawnXPosition = Random.Range(MinX, MaxX);
            float spawnZPosition = Random.Range(MinZ, MaxZ);
            

            PoolMembers[currentPoolMemeber].transform.position = new Vector3(spawnXPosition, spawnYPosition, spawnZPosition);
            currentPoolMemeber++;

            if (currentPoolMemeber >= PoolSize)
            {
                currentPoolMemeber = 0;
            }
            
        }
    }
}
