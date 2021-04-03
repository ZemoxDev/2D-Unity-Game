using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform position1, position2;
    public float speed;
    public Transform startingPosition;

    Vector3 nexPosition;

    private void Start()
    {
        nexPosition = startingPosition.position;
    }

    private void Update()
    {
        if(transform.position == position1.position)
        {
            StartCoroutine(Position1RechedWait());
        }
        if(transform.position == position2.position)
        {
            StartCoroutine(Position2RechedWait());
        }

        transform.position = Vector3.MoveTowards(transform.position, nexPosition, speed * Time.deltaTime);
    }

    IEnumerator Position1RechedWait()
    {
        yield return new WaitForSeconds(5);

        nexPosition = position2.position;
    }

    IEnumerator Position2RechedWait()
    {
        yield return new WaitForSeconds(5);

        nexPosition = position1.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(position1.position, position2.position);
    }
}
