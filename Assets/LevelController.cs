using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private SpawnerController spawner;
    [SerializeField] private GameObject car;

    private Vector2 lastSpawnerCoordinantes;

    void Update()
    {
        
    }

    void Reset()
    {
        throw new NotImplementedException();
    }

    void GenerateSpawner(float difficulty) {
        Instantiate(spawner, );
    }
}
