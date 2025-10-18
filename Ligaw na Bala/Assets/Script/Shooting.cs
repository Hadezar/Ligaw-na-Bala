using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public Bullet bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E) && bullet.bulletSpawned == false)
        {
            shotBullet();
        }
    }
    public void shotBullet()
    {
        GameObject insProj = Instantiate(bulletPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        insProj.GetComponent<Bullet>().Initialize();
    }

}
