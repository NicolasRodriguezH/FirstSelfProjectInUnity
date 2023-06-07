using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    //private float spawnRangeX = 10;
    //private float spawnPosZ;
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;

    public float minDistance = 10f;
    public float maxDistance = 20f;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomObstacle();
        }

    }
    void SpawnRandomObstacle()
    {
        if (transform.position.z < player.position.z + maxDistance)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 1, player.position.z + Random.Range(minDistance, maxDistance));
            GameObject obstacle = Instantiate(obstaclePrefabs[Random.Range(0,obstaclePrefabs.Length)], spawnPosition, obstaclePrefabs[1].transform.rotation);
            obstacle.transform.SetParent(transform);

            if (obstacle.transform.position.y < 0.5f)
            {
                obstacle.transform.position = new Vector3(obstacle.transform.position.x, 0.5f, obstacle.transform.position.z);
            }

            Destroy(obstacle, 4f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Lifes"))
        {
            GameManager.Instance.PerderVida();
        }
    }

}