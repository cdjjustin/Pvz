using System.Collections;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ZombieManager Instance;
    
    public GameObject ZombiePrefab;
    public Transform ZombieBornParent;
    public float SpawnIntervel = 5f;
    private int _zombieSortIndex = 0;
    
    void Awake()
    {
        Instance = this;
    }

    IEnumerator DealyCreateZombie()
    {
        yield return new WaitForSeconds(SpawnIntervel);
        var zombie = Instantiate(ZombiePrefab);
        var bornIndex = Random.Range(1, 6);
        var zombieBornPoint = ZombieBornParent.Find($"born{bornIndex}");
        zombie.transform.SetParent(zombieBornPoint);
        zombie.transform.localPosition = Vector3.zero;
        zombie.GetComponent<SpriteRenderer>().sortingOrder = _zombieSortIndex;
        _zombieSortIndex++;
        StartCoroutine(DealyCreateZombie());
    }
    
    public void CreateZombie()
    {
        StartCoroutine(DealyCreateZombie());
    }
}
