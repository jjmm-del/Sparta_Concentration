using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field:SerializeField]public EnemySO Data { get; private set; }
    [field:Header("Animations")]
    [field:SerializeField]public PlayerAnimationData AnimationData { get; private set; }

    public Animator Animator { get; private set; }
    
    public  CharacterController Controller { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }
    
    private EnemyStateMachine stateMachine;
    
    [field:SerializeField]public Weapon Weapon { get; private set; }

    private void Awake()
    {
        AnimationData.Initialize();
        Animator = GetComponentInChildren<Animator>();
        Controller = GetComponent<CharacterController>();
        ForceReceiver = GetComponent<ForceReceiver>();

        stateMachine = new EnemyStateMachine(this);
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }
}
