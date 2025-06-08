using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private bool alreadyApplyForce;
    private bool alreadyAppliedDealing;
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimationData.AttackParameterHash);
        StartAnimation(stateMachine.Enemy.AnimationData.BaseAttackParameterHash);
        
        alreadyApplyForce = false;
        alreadyAppliedDealing = false;
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.AttackParameterHash);
        StopAnimation(stateMachine.Enemy.AnimationData.BaseAttackParameterHash);
    }
    public override void Update()
    {
        base.Update();

        ForceMove();

        float normalizeTime = GetNormalizedTime(stateMachine.Enemy.Animator, "Attack");
        if (normalizeTime < 1f)
        {
            if (normalizeTime >= stateMachine.Enemy.Data.ForceTransitionTime)
            {
                TryApplyForce();
            }

            if (!alreadyAppliedDealing && normalizeTime >= stateMachine.Enemy.Data.Dealing_Start_TrainsitionTime)
            {
                stateMachine.Enemy.Weapon.SetAttack(stateMachine.Enemy.Data.Damage, stateMachine.Enemy.Data.Force);
                stateMachine.Enemy.Weapon.gameObject.SetActive(true);
                alreadyAppliedDealing = true;
            }

            if (alreadyAppliedDealing && normalizeTime >= stateMachine.Enemy.Data.Dealing_End_TransitionTime)
            {
                stateMachine.Enemy.Weapon.gameObject.SetActive(false);
            }
        }
        else
        {
            if (IsInChasingRange())
            {
                stateMachine.ChangeState(stateMachine.ChasingState);
                return;
            }
            else
            {
                stateMachine.ChangeState(stateMachine.IdleState);
                return;
            }
        }
    }
    void TryApplyForce()
    {
        if (alreadyApplyForce) return;
        alreadyApplyForce = true;

        stateMachine.Enemy.ForceReceiver.Reset();
        stateMachine.Enemy.ForceReceiver.AddForce(Vector3.forward * stateMachine.Enemy.Data.Force);
    }
    
}
