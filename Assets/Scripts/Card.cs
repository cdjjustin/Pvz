using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject objectPrefab;
    private GameObject _clonedObject; //用于展示拖拽的植物
    
    public GameObject darkBg;
    public GameObject progressBar;
    public float coolDownTime;
    public int sunCost;

    private float _timer;
    
    private bool _isCanDrag => SunManager.Instance.TotalSun >= sunCost && _timer >= coolDownTime;

    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        UpdateDarkBg();
        UpdateProgressBar();
    }

    private void UpdateDarkBg()
    {
        darkBg.SetActive(!_isCanDrag);
    }

    private void UpdateProgressBar()
    {
        var isCd = _timer < coolDownTime;
        progressBar.SetActive(isCd);
        if (isCd)
        {
            float ratio = 1 - Mathf.Clamp01(_timer / coolDownTime);
            progressBar.GetComponent<Image>().fillAmount = ratio;
        }
    }

    public Vector3 TranslateScreenToWorld(Vector3 position)
    {
        var cameraTranslatePos = Camera.main.ScreenToWorldPoint(position);
        return new  Vector3(cameraTranslatePos.x, cameraTranslatePos.y, 0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!_isCanDrag)
            return;
            
        if(_clonedObject == null)
        {
            _clonedObject = Instantiate(objectPrefab);
            _clonedObject.transform.position = TranslateScreenToWorld(eventData.position);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(_clonedObject == null || !_isCanDrag)
            return;
        
        _clonedObject.transform.position = TranslateScreenToWorld(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_clonedObject == null || !_isCanDrag)
        {
            return;
        }
        
        var col = Physics2D.OverlapPointAll(TranslateScreenToWorld(eventData.position));
        foreach (var c in col)
        {
            if (c.CompareTag("land") && c.transform.childCount == 0)
            {
                _clonedObject.transform.SetParent(c.transform);
                _clonedObject.transform.localPosition = Vector3.zero;

                _clonedObject = null;
                _timer = 0;
                
                SunManager.Instance.SpendSun(sunCost);
                break;
            }
        }
        
        if (_clonedObject != null)
        {
            Destroy(_clonedObject);
            _clonedObject = null;
        }
    }
}
    
