using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("Speed of the bullet.")]
    public float bulletSpeed = 5f;
    private Vector2 moveDirection;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        if (Camera.main != null)
        {
            mousePos.z = Camera.main.nearClipPlane;
        }
        else
        {
            mousePos.z = 10f;
        }
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        worldMousePos.z = 0f;
        Vector2 targetDirection = (worldMousePos - transform.position).normalized;
        transform.Translate(targetDirection * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            DestroyBullet();
        }
        if (collision.CompareTag("Key"))
        {
            DestroyBullet();
        }
    }

    public void DestroyBullet()
    {
        if (Movement.activeBullet == this)
        {
            Movement.activeBullet = null;
            Movement playerController = FindObjectOfType<Movement>();
            if (playerController != null)
            {
                playerController.SwitchToPlayerCam();
            }
        }
        Destroy(gameObject);
    }
}
