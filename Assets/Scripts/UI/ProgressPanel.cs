using UnityEngine;
using UnityEngine.UI;

public class ProgressPanel : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _bg;
    private GameObject _progress;
    private GameObject _levelText;
    private GameObject _info;
    private GameObject _head;

    private GameObject _flagPrefab;
    
    void Start()
    {
        _bg = transform.Find("Bg").gameObject;
        _progress = transform.Find("Progress").gameObject;
        _levelText = transform.Find("LevelText").gameObject;
        _info = transform.Find("Info").gameObject;
        _head = transform.Find("Head").gameObject;
        
        _flagPrefab = Resources.Load("Prefabs/Flag") as GameObject;
        SetPercent(0.6f);
        SetFlagPercent(0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPercent(float percent)
    {
        //图片进度条
        _progress.GetComponent<Image>().fillAmount = percent;
        _head.GetComponent<RectTransform>().position = GetPercentPos(percent, _head);
    }

    public void SetFlagPercent(float percent)
    {
        var flag = Instantiate(_flagPrefab, transform);
        flag.GetComponent<RectTransform>().position = GetPercentPos(percent, flag);
        _head.transform.SetAsLastSibling();
    }
    
    private Vector2 GetPercentPos(float percent, GameObject obj)
    {
        //进度条最右边位置
        var originPosX = _bg.GetComponent<RectTransform>().position.x + _bg.GetComponent<RectTransform>().sizeDelta.x / 2;
        //进度条宽度
        var width = _bg.GetComponent<RectTransform>().sizeDelta.x;
        //偏移值
        var offset = 10;
        return new Vector2(originPosX - percent * width + offset, obj.GetComponent<RectTransform>().position.y);
    }
}
