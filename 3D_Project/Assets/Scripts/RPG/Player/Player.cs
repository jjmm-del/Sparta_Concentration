using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("Animations")]
    [field: SerializeField]public PlayerAnimationData AnimationData { get; private set; }
    [field:SerializeField] public PlayerSO Data { get; private set; }
    
    public Animator Animator { get; private set; }
    public CharacterController Controller { get; private set; }
    private PlayerStateMachine stateMachine;

    private void Awake()
    {
        AnimationData.Initialize();
        
        Animator = GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();
        stateMachine = new PlayerStateMachine(this);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }
    
}
