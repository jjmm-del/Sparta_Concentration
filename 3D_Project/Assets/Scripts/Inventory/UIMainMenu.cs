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
        GoldText.text = GameManager.Instance.PlayerGold.ToString(); // 3자리마다 ,추가하기
        TitleText.text = GameManager.Instance.PlayerTitle; // 칭호
        NameText.text = GameManager.Instance.PlayerName; // 이름 영어만 됨
        DescriptionText.text = GameManager.Instance.PlayerDescription; // 
        LevelText.text = GameManager.Instance.PlayerLevel.ToString(); // 그냥 써도 되나
        ExpText.text = GameManager.Instance.PlayerExp.ToString(); // 레벨 별 {현재Exp/최대Exp}이렇게 넣어야됨
    }

    private void Start()
    {
        InventoryButton.onClick.AddListener(UIManager.Instance.OpenInventory);
        StatusButton.onClick.AddListener(UIManager.Instance.OpenStatus);
    }
    

    
    
}
