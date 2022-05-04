using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintTimer : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        float hold = PlayerPrefs.GetFloat("TimePlayed", 0);
        text.text = "Time Player : " + hold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
