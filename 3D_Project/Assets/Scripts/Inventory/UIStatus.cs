using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private Image AttackIcon;
    [SerializeField] private TextMeshProUGUI AttackText;
    [SerializeField] private Image DefenseIcon;
    [SerializeField] private TextMeshProUGUI DefenseText;
    [SerializeField] private Image HealthIcon;
    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] private Image CriticalIcon;
    [SerializeField] private TextMeshProUGUI CriticalText;
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
        
    }

    
    
}
