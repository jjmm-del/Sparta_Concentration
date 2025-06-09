using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; }
    
    public Vector2 MovementDirection { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; }
    
    public GameObject Target { get; private set; }
    
    public EnemyIdleState IdleState { get; }
    public EnemyChasingState ChasingState { get; }
    public EnemyAttackState Attackstate { get; }

    public EnemyStateMachine(Enemy enemy)
    {
        this.Enemy = enemy;
        Target = GameObject.FindGameObjectWithTag("Player");

        IdleState = new EnemyIdleState(this);
        ChasingState = new EnemyChasingState(this);
        Attackstate = new EnemyAttackState(this);
    }
}
