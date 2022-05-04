using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    float currentTime;

    private void Start()
    {
        currentTime = 0;
        PlayerPrefs.SetFloat("TimePlayed", currentTime);
    }

    public float getTime()
    {
        return currentTime;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        PlayerPrefs.SetFloat("TimePlayed", currentTime);
    }
}
