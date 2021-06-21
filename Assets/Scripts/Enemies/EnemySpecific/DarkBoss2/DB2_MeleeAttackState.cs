using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB2_MeleeAttackState : MeleeAttackState
{
    private DarkBoss2 enemy;

    public DB2_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, DarkBoss2 enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else if (!isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private Projectile projectileScript;

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        GameObject.Instantiate(enemy.projectile, enemy.meleeAttackPositionRange1.position, enemy.meleeAttackPositionRange1.rotation);
        projectileScript = enemy.projectile.GetComponent<Projectile>();
        projectileScript.FireProjectile(55, 18, 12);
    }
}
