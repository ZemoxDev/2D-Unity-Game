using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkEnemy3 : Entity
{
    public DE3_IdleState idleState { get; private set; }

    public DE3_MoveState moveState { get; private set; }

    public DE3_PlayerDetected playerDetectedState { get; private set; }
    public DE3_LookForPlayer lookForPlayerState { get; private set; }
    public DE3_MeleeAttackState meleeAttackState { get; private set; }
    public DE3_ChargeState chargeState { get; private set; }
    public DE3_StunState stunState { get; private set; }
    public DE3_DeadState deadState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;

    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Start()
    {
        base.Start();

        moveState = new DE3_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new DE3_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new DE3_PlayerDetected(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new DE3_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new DE3_LookForPlayer(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new DE3_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        stunState = new DE3_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new DE3_DeadState(this, stateMachine, "dead", deadStateData, this);

        stateMachine.Initialize(moveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if (isDead)
        {
            stateMachine.ChangeState(deadState);
            Destroy(gameObject);
        }
        else if (isStunned && stateMachine.currentState != stunState)
        {
            stateMachine.ChangeState(stunState);
        }
        else if (!CheckPlayerInMinAgroRange())
        {
            StartCoroutine(TurnAttack());
        }
    }

    IEnumerator TurnAttack()
    {
        lookForPlayerState.SetTurnImmediately(true);
        yield return new WaitForSeconds(0.1f);
        stateMachine.ChangeState(meleeAttackState);
    }
}
