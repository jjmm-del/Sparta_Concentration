using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI AttackText;
    [SerializeField] private TextMeshProUGUI DefenseText;
    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] private TextMeshProUGUI CriticalText;
    [SerializeField] private Image AttackIcon;
    [SerializeField] private Image DefenseIcon;
    [SerializeField] private Image HealthIcon;
    [SerializeField] private Image CriticalIcon;
    [SerializeField] private Button BackButton;

    private void Awake()
    {
        //초기화
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        BackButton.onClick.AddListener(UIManager.Instance.OpenMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        AttackText.text = AttackStat();
        DefenseText.text = DefenseStat();
        HealthText.text = HealthStat();
        CriticalText.text = CriticalStat();
    }

    string AttackStat()
    {
        string _attackText;
        int currentAttack = GameManager.Instance.PlayerAttack; // + WeaponAttack  이걸 어디서 관리하까
        _attackText = $"Attack \n {currentAttack}";
        return _attackText;
    }
    string DefenseStat()
    {
        string _defenseText;
        int _currentDefense = GameManager.Instance.PlayerDefense;
        _defenseText = $"Defense \n {_currentDefense}";
        return _defenseText;
    }
    string HealthStat()
    {
        string _healthText;
        int _currentHealth = GameManager.Instance.PlayerHealth;
        _healthText = $"Health \n {_currentHealth}";
        return _healthText;
    }
    string CriticalStat()
    {
        string _criticalText;
        int _currentCritical = GameManager.Instance.PlayerCriticalChance;
        _criticalText = $"CriticalChance \n {_currentCritical}";
        return _criticalText;
    }
    
    
}
