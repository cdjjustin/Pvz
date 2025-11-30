using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ZombieManager Instance;
    
    public Transform ZombieBornParent;
    private int _zombieSortIndex = 0;

    private int _currentLevel = 1;
    private int _currentProgress = 1;
    private readonly List<GameObject> _zombieList = new List<GameObject>();
    
    void Awake()
    {
        Instance = this;
    }

    IEnumerator DealyCreateZombie(LevelManagerData levelData)
    {
        yield return new WaitForSeconds(levelData.createTime);
        var zombiePrefab = Resources.Load($"Prefabs/Zombie{levelData.zombieType}") as GameObject;
        var zombie = Instantiate(zombiePrefab);
        var bornIndex = levelData.bornPos + 1;
        var zombieBornPoint = ZombieBornParent.Find($"born{bornIndex}");
        zombie.transform.SetParent(zombieBornPoint);
        zombie.transform.localPosition = Vector3.zero;
        zombie.GetComponent<SpriteRenderer>().sortingOrder = _zombieSortIndex;
        _zombieSortIndex++;
        _zombieList.Add(zombie);
    }
    
    public void CreateZombie()
    {
        //StartCoroutine(DealyCreateZombie());
        var canCreate = false;
        for (int i = 0; i < ConfigManager.LevelManagerDataList.Count; i++)
        {
            var levelData = ConfigManager.LevelManagerDataList[i];
            // 检查并创建当前关卡和进度的僵尸
            if (levelData.levelId == _currentLevel && levelData.progressId == _currentProgress)
            {
                StartCoroutine(DealyCreateZombie(levelData));
                canCreate = true;
            }
        }

        if (!canCreate)
        {
            StopAllCoroutines();
            Debug.Log("All Zombies Cleared!");
            _zombieList.Clear();
            //Todo: Game Win Logic
        }
    }
    
    public void RemoveZombie(GameObject zombie)
    {
        if (_zombieList.Contains(zombie))
        {
            _zombieList.Remove(zombie);
        }

        if (_zombieList.Count == 0)
        {
            _currentProgress++;
            CreateZombie();
        }
    }
}
