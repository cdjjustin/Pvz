using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text sunCountText;
    private void Awake()
    {
        instance = this;
    }

    public void UpdateSunCount()
    {
        sunCountText.text = SunManager.Instance.TotalSun.ToString();
    }
}