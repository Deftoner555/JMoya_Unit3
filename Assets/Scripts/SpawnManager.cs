using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obsPrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    void Start()
    {
        InvokeRepeating("SpawnObs", 2, 2);
    }

    void Update()
    {
        
    }
    void SpawnObs()
    {
        Instantiate(obsPrefab, spawnPos, obsPrefab.transform.rotation);
    }
}
