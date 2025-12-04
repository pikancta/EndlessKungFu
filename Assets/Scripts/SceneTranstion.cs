using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class SceneTranstion : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("PlayerTest");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }


    
}
