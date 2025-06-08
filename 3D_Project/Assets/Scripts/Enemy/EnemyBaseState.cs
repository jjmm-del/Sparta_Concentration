using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine stateMachine;
    //protected readonly PlayerGroundData groundData;
    public EnemyBaseState(EnemyStateMachine playerStateMachine)
    {
        stateMachine = playerStateMachine;
        //
    }
    
    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }

    
}
