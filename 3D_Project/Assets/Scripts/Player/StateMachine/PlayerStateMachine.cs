using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }
    
    public Vector2 MovementDirection { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;
    
    public bool IsAttacking { get; set; }
    public Transform MainCameraTransform { get; set; }
    
    public Health Target { get; private set; }
    public PlayerIdleState IdleState { get; }
    public PlayerChasingState ChasingState { get; }
    public PlayerAttackState AttackState { get; }
    

    public PlayerStateMachine(Player player)
    {
        this.Player = player;
        MainCameraTransform = Camera.main.transform;

        IdleState = new PlayerIdleState(this);
        ChasingState = new PlayerChasingState(this);
        AttackState = new PlayerAttackState(this);

        MovementSpeed = player.Data.GroundData.BaseSpeed;
        RotationDamping = player.Data.GroundData.BaseRotationDamping;
    }
}
