using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour
{
    public float spawnOffset = 10;
    public bool isVerticle;

    [SerializeField]
    private GameObject _goblinPrefab;

    [SerializeField]
    private float minimumSpawnTime;

    [SerializeField]
    private float maximumSpawnTime;

    private float timeUntilSpawn;
    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if(timeUntilSpawn < 0)
        {
            if (isVerticle)
            {
                float lowestPoint = transform.position.x - spawnOffset;
                float highestPoint = transform.position.x + spawnOffset;

                GameObject newGoblin = Instantiate(_goblinPrefab, new Vector3(Random.Range(lowestPoint, highestPoint), transform.position.y, 0), Quaternion.identity);
                newGoblin.transform.localScale = new Vector3(3, 3, 1);
            }
            else
            {
                float lowestPoint = transform.position.y - spawnOffset;
                float highestPoint = transform.position.y + spawnOffset;

                GameObject newGoblin = Instantiate(_goblinPrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), Quaternion.identity);
                newGoblin.transform.localScale = new Vector3(3, 3, 1);
            }
            
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
