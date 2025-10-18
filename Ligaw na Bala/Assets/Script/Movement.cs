using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public Bullet bullet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bullet.bulletSpawned == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.transform.rotation = Quaternion.Euler(0, -180, 0);
                rb.transform.position = new Vector2(rb.transform.position.x - 1 * Time.fixedDeltaTime, rb.transform.position.y);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.transform.rotation = Quaternion.Euler(0, 0, 0);
                rb.transform.position = new Vector2(rb.transform.position.x + 1 * Time.fixedDeltaTime, rb.transform.position.y);
            }
        }           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
