using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public bool bulletSpawned;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        bulletSpawned = false;
    }
    void Update()
    {
        rb.transform.position = new Vector2(rb.transform.position.x + 1 * Time.fixedDeltaTime, rb.transform.position.y);
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.rotation = Quaternion.Euler(0, -1800, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.transform.rotation = Quaternion.Euler(0,0,- 90);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        rb.transform.position = new Vector2(rb.transform.position.x + 1 * Time.fixedDeltaTime, rb.transform.position.y);
    }
    public void Initialize()
    {
        rb.AddForce(transform.forward, ForceMode2D.Force);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
