using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PlayerGroundData
{
    [field:SerializeField][field:Range(0f,25f)]public float BaseSpeed { get; private set; } = 5f;
    [field:SerializeField][field:Range(0f,25f)]public float BaseRotationDamping { get; private set; } = 1f;
    
    [field:Header("IdleData")]
    
    [field:Header("WalkData")]
    [field:SerializeField][field:Range(0f,2f)]public float WalkSpeedModifier { get; private set; }=0.225f;
    
    [field:Header("RunData")]
    [field:SerializeField][field:Range(0f,2f)]public float RunSpeedModifier { get; private set; }= 1f;
}


[Serializable]
public class PlayerAttackData
{
    [field:SerializeField] public string AttackName { get; private set; }
    [field:SerializeField] public float EnemyChasingRange { get; private set; } = 10f;
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public int Damage;
    [field:SerializeField][field:Range(0f,1f)] public float Dealing_Start_TransitionTime { get; private set; }
    [field:SerializeField][field:Range(0f,1f)] public float Dealing_End_TransitionTime { get; private set; }

}











[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    [field:SerializeField] public PlayerGroundData GroundData { get; private set; }
    [field:SerializeField] public PlayerAttackData AttackData { get; private set; }
    
}
