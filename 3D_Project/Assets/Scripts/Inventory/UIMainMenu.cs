using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMainMenu : MonoBehaviour
{
    [Header("GoldPanel")] [SerializeField] private Image GoldIcon;
    [SerializeField] private TextMeshProUGUI GoldText;

    [Header("CharacterInfoPanel")] [SerializeField]
    private TextMeshProUGUI TitleText;
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
        
        //데이터 초기화
        //GoldText.text = GameManager.Instance.Player.currentMoney.Tostring();
        //GoldText.text = GameManager.Instance.Player.title;
        //GoldText.text = GameManager.Instance.Player.name;
        //GoldText.text = GameManager.Instance.Player.description;
        //GoldText.text = GameManager.Instance.Player.currentLevel;
        //GoldText.text = GameManager.Instance.Player.currentExp;
    }

    private void Update()
    {
        //상태를 계속 업데이트?
    }

    private void Start()
    {
        InventoryButton.onClick.AddListener(UIManager.Instance.OpenInventory);
        StatusButton.onClick.AddListener(UIManager.Instance.OpenStatus);
    }
    

    
    
}
