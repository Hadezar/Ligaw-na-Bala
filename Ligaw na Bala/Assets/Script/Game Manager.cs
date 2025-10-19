using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentBuildIndex;
    public static Bullet activeBullet = null;

    public GameObject pauseGO;

    private void Start()
    {
        pauseGO.SetActive(false);
        Time.timeScale = 1f;
    }
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        currentBuildIndex = currentScene.buildIndex;

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(currentBuildIndex);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            pauseGO.SetActive(true);            
        }

        if (pauseGO.activeInHierarchy)
        {
            Time.timeScale = 0f;
        }
    } 

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
