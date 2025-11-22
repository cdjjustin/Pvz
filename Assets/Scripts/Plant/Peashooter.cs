using UnityEngine;

public class Peashooter : PlantBase
{
    // Start is called before the first frame update
    public float intervel = 2f;
    private float _timer;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPos;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= intervel)
        {
            _timer = 0f;
            Shoot();
        }
    }
    
    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPos.position, Quaternion.identity);
    }
}
