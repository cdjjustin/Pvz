using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peashooter : MonoBehaviour
{
    // Start is called before the first frame update
    public float intervel = 2f;
    public float timer;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPos;
    
    void Start()
    {
        
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
