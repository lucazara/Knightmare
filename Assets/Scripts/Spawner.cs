using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float t;
    public float secondsBetweenSpawns;

    private void Start()
    {
        t = 0;
    }

    private void Update()
    {
        t += Time.deltaTime;

        if (t > secondsBetweenSpawns)
        {
            Spawn();
            t = 0;
        }

    }

    private void Spawn()
    {

    }
}
