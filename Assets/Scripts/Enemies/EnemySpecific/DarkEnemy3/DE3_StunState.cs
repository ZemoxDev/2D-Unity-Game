using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DE3_StunState : StunState
{
    private DarkEnemy3 enemy;

    public DE3_StunState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData, DarkEnemy3 enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isStunTimeOver)
        {
            if (performShortRangeAction)
            {
                stateMachine.ChangeState(enemy.meleeAttackState);
            }
            else
            {
                enemy.lookForPlayerState.SetTurnImmediately(true);
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}