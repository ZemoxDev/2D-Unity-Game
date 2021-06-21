using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBoss2 : Entity
{
    public DB2_MoveState moveState { get; private set; }

    public DB2_IdleState idleState { get; private set; }

    public DB2_PlayerDetectedState playerDetectedState { get; private set; }

    public DB2_MeleeAttackState meleeAttackState { get; private set; }

    public DB2_LookForPlayerState lookForPlayerState { get; private set; }

    public DB2_StunState stunState { get; private set; }

    public DB2_DeadState deadState { get; private set; }

    public DB2_DodgeState dodgeState { get; private set; }

    public DB2_RangedAttackState rangedAttackState { get; private set; }

    public float halfHealth;
    private float originalHealth;

    private bool setHealth;

    public GameObject projectile;

    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
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
    private Transform meleeAttackPosition;
    [SerializeField]
    private Transform rangedAttackPosition;

    public Transform meleeAttackPositionRange1;

    public Transform meleeAttackPositionRange2;

    public Transform meleeAttackPositionRange3;

    public override void Start()
    {
        base.Start();

        moveState = new DB2_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new DB2_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new DB2_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        meleeAttackState = new DB2_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        lookForPlayerState = new DB2_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        stunState = new DB2_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new DB2_DeadState(this, stateMachine, "dead", deadStateData, this);
        dodgeState = new DB2_DodgeState(this, stateMachine, "dodge", dodgeStateData, this);
        rangedAttackState = new DB2_RangedAttackState(this, stateMachine, "rangedAttack", rangedAttackPosition, rangedAttackStateData, this);

        stateMachine.Initialize(moveState);

        originalHealth = currentHealth;
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
        else if (CheckPlayerInMinAgroRange())
        {
            stateMachine.ChangeState(rangedAttackState);
        }
        else if (!CheckPlayerInMinAgroRange())
        {
            lookForPlayerState.SetTurnImmediately(true);
            stateMachine.ChangeState(lookForPlayerState);
        }

        if (currentHealth <= halfHealth && setHealth == false)
        {
            currentHealth = originalHealth;
            setHealth = true;
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}
