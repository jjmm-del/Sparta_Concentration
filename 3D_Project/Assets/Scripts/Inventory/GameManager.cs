using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Character Player;
    
    
    public int PlayerGold; 
    public int PlayerAttack; 
    public int PlayerDefense;
    public int PlayerHealth; 
    public int PlayerCriticalChance;
    public int PlayerLevel; 
    public int PlayerCurrentExp;
    public int PlayerMaxExp;
    public string PlayerTitle;
    public string PlayerDescription;
    public string PlayerName;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    void Awake()
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
        
        SetData();
    }
    void SetData()
    {
        Player = new Character();
        PlayerGold = Player.Gold;
        PlayerAttack = Player.Attack;
        PlayerDefense = Player.Defense;
        PlayerHealth = Player.Health;
        PlayerCriticalChance = Player.CriticalChance;
        PlayerLevel = Player.Level;
        PlayerCurrentExp = Player.CurrentExp;
        PlayerMaxExp = Player.MaxExp;
        PlayerName = Player.Name;
        PlayerDescription = Player.Description;
        PlayerTitle = Player.Title;
    }

}
