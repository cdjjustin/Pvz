using UnityEngine;

public class SunFlower : PlantBase
{
    // Start is called before the first frame update
    public float readyTime;
    private float _timer;
    
    public GameObject sunPrefab;
    private int _sunCount;

    public override void Start()
    {
        base.Start();
        _timer = 0;
        _sunCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > readyTime)
        {
            animator?.SetBool("Ready", true);
        }
    }

    public void SpawnSun()
    {
        _sunCount++;
        var randomOffsetX = _sunCount % 2 > 0
            ? Random.Range(transform.position.x - 1f, transform.position.x - 0.5f)
            : Random.Range(transform.position.x + 0.5f, transform.position.x + 1f);
        var randomOffsetY = Random.Range(transform.position.y - 0.3f, transform.position.y + 0.5f);
        
        var newSun = Instantiate(sunPrefab);
        newSun.transform.position = new Vector3(randomOffsetX, randomOffsetY, -.1f);
        _timer = 0;
        animator?.SetBool("Ready", false);
    }
}
