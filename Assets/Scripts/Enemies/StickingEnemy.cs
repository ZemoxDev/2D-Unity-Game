using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickingEnemy : MonoBehaviour
{
    public float speed;
    public GameObject[] turnPoints;

    int nextTurnPoint = 1;
    float distToPoint;

    [SerializeField]
    private float damageRadius;
    [SerializeField]
    private LayerMask whatIsPlayer;
    [SerializeField]
    private Transform damagePosition;

    public float damage;

    private AttackDetails attackDetails;

    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Collider2D damageHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsPlayer);
        attackDetails.damageAmount = damage;

        if (damageHit)
        {
            damageHit.transform.SendMessage("Damage", attackDetails);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
    }

    void Move()
    {
        distToPoint = Vector2.Distance(transform.position, turnPoints[nextTurnPoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, turnPoints[nextTurnPoint].transform.position, speed * Time.deltaTime);

        if (distToPoint < 0.1f)
        {
            Turn();
        }
    }

    void Turn()
    {
        Vector3 currRot = transform.eulerAngles;
        currRot.z += turnPoints[nextTurnPoint].transform.eulerAngles.z;
        transform.eulerAngles = currRot;
        ChooseNextPoint();
    }

    void ChooseNextPoint()
    {
        nextTurnPoint++;

        if(nextTurnPoint == turnPoints.Length)
        {
            nextTurnPoint = 0;
        }
    }
}
