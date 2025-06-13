using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //임시로 값 넣어놓기
    public int Gold { get; private set; } = 12345;
    public int Attack { get; private set; } = 35;
    public int Defense { get; private set; } = 40;
    public int Health { get; private set; } = 100;
    public int CriticalChance { get; private set; } = 25;
    public int Level { get; private set; } = 10;
    public int CurrentExp { get; private set; } = 8;
    public int MaxExp { get; private set; } = 20;

    public string Title { get; private set; } = "Coder";
    public string Description { get; private set; } = "He writes code everyday 9 to 9";
    public string Name { get; private set; } = "Chad";
}
