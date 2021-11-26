using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void LoadSceneTwo()
    {
        SceneManager.LoadScene(0);
    }
}
