using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [field:SerializeField]
    public UIMainMenu UIMainMenu { get;  private set; }
    [field:SerializeField]
    public UIInventory UIInventory { get;  private set; }
    [field:SerializeField]
    public UIStatus UIStatus { get;  private set; }
    
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("UIManager").AddComponent<UIManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

        
    }


    public void OpenMainMenu() // 이름은 open mainmenu지만 메인메뉴는 항상 켜져있으므로 status창과 inventory창을 종료
    {
        UIInventory.gameObject.SetActive(false);
        UIStatus.gameObject.SetActive(false);
    }
    public void OpenInventory()
    {
        UIInventory.gameObject.SetActive(true);
    }

    public void OpenStatus()
    {
        UIStatus.gameObject.SetActive(true);
    }
}