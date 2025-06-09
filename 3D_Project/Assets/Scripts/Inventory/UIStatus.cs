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
        AttackText.text = GameManager.Instance.PlayerAttack.ToString();
        DefenseText.text = GameManager.Instance.PlayerDefense.ToString();
        HealthText.text = GameManager.Instance.PlayerHealth.ToString();
        CriticalText.text = GameManager.Instance.PlayerCriticalChance.ToString();
    }

    
    
}
