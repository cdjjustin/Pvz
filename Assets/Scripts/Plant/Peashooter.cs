using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Peashooter : PlantBase
{
    // Start is called before the first frame update
    public float intervel = 2f;
    public float timer;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPos;
    
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= intervel)
        {
            timer = 0f;
            Shoot();
        }
    }
    
    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPos.position, Quaternion.identity);
    }
}
