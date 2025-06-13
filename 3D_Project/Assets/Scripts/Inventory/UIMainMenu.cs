using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMainMenu : MonoBehaviour
{
    [Header("GoldPanel")]
    [SerializeField] private Image GoldIcon;
    [SerializeField] private TextMeshProUGUI GoldText;

    [Header("CharacterInfoPanel")]
    [SerializeField] private TextMeshProUGUI TitleText;
    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField] private TextMeshProUGUI DescriptionText;
    [SerializeField] private TextMeshProUGUI LevelText;
    [SerializeField] private TextMeshProUGUI ExpText;
    [SerializeField] private Image ExpGauge;

    [Header("Status,InventoryButton")]
    [SerializeField] private Button InventoryButton;
    [SerializeField] private Button StatusButton;

    
    private void Awake()
    {
        //데이터 초기화 할 필요가 없었네 GameManager에서 초기화함
        
    }

    private void Update()
    {
        //상태를 계속 업데이트?
        GoldText.text = GoldIndexing(GameManager.Instance.PlayerGold);
        TitleText.text = GameManager.Instance.PlayerTitle; // 칭호
        NameText.text = GameManager.Instance.PlayerName; // 이름 영어만 됨
        DescriptionText.text = GameManager.Instance.PlayerDescription; // 설명 까지는 그냥 넣어도될듯
        LevelText.text = PlayerLevel(GameManager.Instance.PlayerLevel); // lv붙여야됨
        ExpSet();
    }

    private void Start()
    {
        InventoryButton.onClick.AddListener(UIManager.Instance.OpenInventory);
        StatusButton.onClick.AddListener(UIManager.Instance.OpenStatus);
    }


    string GoldIndexing(int _gold) //골드를 string으로 넣기 어차피 text는 string
    {
        string result = _gold.ToString();
        // if (_gold == 0)
        // {
        //     return "0";
        // }
        //
        // int unitIndex = 0;
        // 
        // while (_gold > 0)
        // {
        //     int unitValue = _gold % 1000;
        //     _gold /= 1000;
        //     if (unitValue > 0)
        //     {
        //         result = unitValue.ToString() + "," + result;
        //     }
        //     unitIndex++;
        // }

        return result;
    }

    string PlayerLevel(int _level)
    {
        string result = $"Lv. {_level}";
        return result;
    }

    void ExpSet()
    {
        ExpGauge.fillAmount = (float)GameManager.Instance.PlayerCurrentExp / GameManager.Instance.PlayerMaxExp;
        ExpText.text = $"{GameManager.Instance.PlayerCurrentExp}/{GameManager.Instance.PlayerMaxExp}";
    }
    
}
