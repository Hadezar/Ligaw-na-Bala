using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject needKeyGO;

    private float screenTime;

    public Key key;
    private void Start()
    {
        screenTime = 2f;
        needKeyGO.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (key.gotKey == true)
            {
                SceneManager.LoadSceneAsync(2);
            }
            else
            {
                needKeyGO.SetActive(true);
                screenTime -= Time.deltaTime;
                if (screenTime <= 0)
                {
                    needKeyGO.SetActive(false);
                    screenTime = 2f;
                }
            }
        }
    }
}
