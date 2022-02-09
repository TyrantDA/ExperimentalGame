using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    float currentTime;
    float minTimeBetweenSpawns = 1;
    float maxTimeBetweenSpawns = 5;

    private void Start()
    {
        currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
    }


    private void Update()
    {
        currentTime -= Time.deltaTime;

        if(currentTime<=0)
        {
            Debug.Log("fire");
            currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
        }
    }
}
