using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Runtime.InteropServices;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Config")]
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float repeatRate = 1.5f;

    [Header("Obstacle Prefabs")]
    [SerializeField] private List<GameObject> obstaclePrefab;

    [Header("Spawn Reference")]
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    }

    void Update()
    {
        if (PlayerController.instance.gameOver)
        {
            CancelInvoke(nameof(SpawnObstacle));
        }
    }

    void SpawnObstacle()
    {
        if(obstaclePrefab.Count != 0 && spawnPoint != null)
        {
            //Random prefab choose
            int index = Random.Range(0, obstaclePrefab.Count);
            GameObject chosenPrefab = obstaclePrefab[index];
            //To spawn the objects
            Instantiate(chosenPrefab, spawnPoint.position,spawnPoint.rotation);
        }
        else
        {
            Debug.Log("Error: system cannot spawn the object!");
        }
    }
}
