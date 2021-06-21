﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DE3_LookForPlayer : LookForPlayerState
{
    private DarkEnemy3 enemy;

    public DE3_LookForPlayer(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayer stateData, DarkEnemy3 enemy) : base(etity, stateMachine, animBoolName, stateData)
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

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if (isAllTurnsTimeDone)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
