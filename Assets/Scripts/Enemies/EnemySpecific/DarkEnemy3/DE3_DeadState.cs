using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DE3_DeadState : DeadState
{
    private DarkEnemy3 enemy;

    public DE3_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, DarkEnemy3 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}