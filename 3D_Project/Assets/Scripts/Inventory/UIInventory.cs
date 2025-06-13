using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Button BackButton;

    void Awake()
    {
        
        
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
