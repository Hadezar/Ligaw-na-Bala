using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    public bool gotKey;

    private void Start()
    {
        gotKey = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gotKey = true;
            Destroy(gameObject);
        }

        if (collision.CompareTag("Bullet"))
        {
            gotKey = true;
            Destroy(gameObject);
        }
    }
}
