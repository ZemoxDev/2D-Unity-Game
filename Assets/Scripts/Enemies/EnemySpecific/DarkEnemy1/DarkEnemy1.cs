using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkEnemy1 : Entity
{
    public DE1_MoveState moveState { get; private set; }

    public DE1_IdleState idleState { get; private set; }

    public DE1_PlayerDetectedState playerDetectedState { get; private set; }

    public DE1_LookForPlayerState lookForPlayerState { get; private set; }

    public DE1_StunState stunState { get; private set; }

    public DE1_DeadState deadState { get; private set; }

    public DE1_DodgeState dodgeState { get; private set; }

    public DE1_RangedAttackState rangedAttackState { get; private set; }

    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    public D_DodgeState dodgeStateData;
    [SerializeField]
    private D_RangedAttackState rangedAttackStateData;

    [SerializeField]
    private Transform rangedAttackPosition;

    public override void Start()
    {
        base.Start();

        moveState = new DE1_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new DE1_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new DE1_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        lookForPlayerState = new DE1_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        stunState = new DE1_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new DE1_DeadState(this, stateMachine, "dead", deadStateData, this);
        dodgeState = new DE1_DodgeState(this, stateMachine, "dodge", dodgeStateData, this);
        rangedAttackState = new DE1_RangedAttackState(this, stateMachine, "rangedAttack", rangedAttackPosition, rangedAttackStateData, this);

        stateMachine.Initialize(moveState);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if (isDead)
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Death");
            stateMachine.ChangeState(deadState);
        }
        else if (isStunned && stateMachine.currentState != stunState)
        {
            stateMachine.ChangeState(stunState);
        }
        else if (CheckPlayerInMinAgroRange())
        {
            stateMachine.ChangeState(rangedAttackState);
        }
        else if (!CheckPlayerInMinAgroRange())
        {
            StartCoroutine(TurnAttack());
        }
    }

    IEnumerator TurnAttack()
    {
        lookForPlayerState.SetTurnImmediately(true);
        yield return new WaitForSeconds(0.05f);
        stateMachine.ChangeState(rangedAttackState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}
