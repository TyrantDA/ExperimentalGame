using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public string NextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(NextScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
