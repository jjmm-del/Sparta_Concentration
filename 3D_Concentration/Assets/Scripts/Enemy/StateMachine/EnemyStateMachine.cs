using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; }
    
    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;
    
    public Health Target { get; private set; }
    public EnemyIdleState IdleState {get;}
    public EnemyChasingState ChasingState {get;}
    public EnemyAttackState AttackState { get; }

    public EnemyStateMachine(Enemy enemy)
    {
        this.Enemy = enemy;
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

        IdleState = new EnemyIdleState(this);
        ChasingState = new EnemyChasingState(this);
        AttackState = new EnemyAttackState(this);
        
        MovementSpeed = enemy.Data.GroundData.BaseSpeed;
        RotationDamping = enemy.Data.GroundData.BaseRotationDamping;
    }
}
