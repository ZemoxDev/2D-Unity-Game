using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkEnemy5 : Entity
{
    public DE5_IdleState idleState { get; private set; }

    public DE5_MoveState moveState { get; private set; }

    public DE5_PlayerDetected playerDetectedState { get; private set; }
    public DE5_LookForPlayer lookForPlayerState { get; private set; }
    public DE5_MeleeAttackState meleeAttackState { get; private set; }
    public DE5_ChargeState chargeState { get; private set; }
    public DE5_StunState stunState { get; private set; }
    public DE5_DeadState deadState { get; private set; }

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

        moveState = new DE5_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new DE5_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new DE5_PlayerDetected(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new DE5_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new DE5_LookForPlayer(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new DE5_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        stunState = new DE5_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new DE5_DeadState(this, stateMachine, "dead", deadStateData, this);

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
            FindObjectOfType<AudioManager>().Play("Death");
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
