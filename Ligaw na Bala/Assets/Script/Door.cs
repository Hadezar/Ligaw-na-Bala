using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject needKeyGO;
    public GameManager gm;
    public Key key;

    private float screenTime = 2f;

    private void Start()
    {

    }

    private void Update()
    {
        if (needKeyGO.activeInHierarchy)
        {
            screenTime -= Time.deltaTime;
            if (screenTime <= 0)
            {
                needKeyGO.SetActive(false);
                screenTime = 2f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (key.gotKey == true)
            {
                SceneManager.LoadSceneAsync(gm.currentBuildIndex + 1);                
            }
            else if (key.gotKey == false)
            {
                needKeyGO.SetActive(true);                
            }           
        }
    }
}
