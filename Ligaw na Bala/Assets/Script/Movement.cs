using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform shootingPoint; 
    public CinemachineVirtualCamera bulletVCamera;
    private bool isCameraFollowingBullet = false;
    public static Bullet activeBullet = null;
    private Animator animator;

    private void Start()
    {
        bulletVCamera.gameObject.SetActive(false);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (activeBullet != null)
        {
            if (!isCameraFollowingBullet)
            {
                SwitchToBulletCam(activeBullet.transform);
            }
            animator.SetBool("isShooting", true);
            animator.SetBool("isWalking", false);
            return;
        }
        else
        {
            if (isCameraFollowingBullet)
            {
                SwitchToPlayerCam();
            }
            animator.SetBool("isShooting", false);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        animator.SetBool("isWalking", Mathf.Abs(horizontalInput) > 0.01f);

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (activeBullet == null)
            {
                bulletVCamera.gameObject.SetActive(true);
          
                Vector3 spawnPosition = shootingPoint.position;
                GameObject bulletGO = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
                Bullet newBullet = bulletGO.GetComponent<Bullet>();
                activeBullet = newBullet;
                SwitchToBulletCam(bulletGO.transform);
            }
        }
    }

    private void SwitchToBulletCam(Transform target)
    {
        if (bulletVCamera != null)
        {
            bulletVCamera.Follow = target;
            bulletVCamera.Priority = 12;
            isCameraFollowingBullet = true;
        }
    }

    public void SwitchToPlayerCam()
    {
        if (bulletVCamera != null)
        {
            bulletVCamera.Priority = 8;
            bulletVCamera.Follow = null;
            isCameraFollowingBullet = false;
        }
    }
}