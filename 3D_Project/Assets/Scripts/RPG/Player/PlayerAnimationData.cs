using System;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string walkParameterName = "Walk"; //Enemy는 Walk
    [SerializeField] private string runParameterName = "Run"; //Player는 Run
    
    [SerializeField] private string attackParameterName = "Attack"; //공격
    //[SerializeField] private string skillParameterName = "Skill"; // 스킬, 쓸지 안쓸지 모름
    
    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }
    
    public int AttackParameterHash { get; private set; }

    public void Initialize()
    {
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        WalkParameterHash = Animator.StringToHash(walkParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);
        
        AttackParameterHash = Animator.StringToHash(attackParameterName);
    }

}
