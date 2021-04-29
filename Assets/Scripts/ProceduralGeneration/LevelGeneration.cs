using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPosition;
    public GameObject[] landscapes;

    private int direction;
    public float moveAmount;

    private float timeBtwLandscapes;
    public float startTimeBtwLandscapes = 0.25f;

    private bool stopGeneration;

    private void Start()
    {
        int randStartingPos = Random.Range(0, startingPosition.Length);
        transform.position = startingPosition[randStartingPos].position;
        Instantiate(landscapes[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);

        StartCoroutine(StopGen());
    }

    private void Update()
    {
        if(timeBtwLandscapes <= 0 && stopGeneration == false)
        {
            Move();
            timeBtwLandscapes = startTimeBtwLandscapes;
        }
        else
        {
            timeBtwLandscapes -= Time.deltaTime;
        }
    }

    private void Move()
    {
        if(stopGeneration == false)
        {
            Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
            transform.position = newPos;

            int rand = Random.Range(0, landscapes.Length);
            Instantiate(landscapes[rand], transform.position, Quaternion.identity);
        }
    }

    IEnumerator StopGen()
    {
        yield return new WaitForSeconds(12f);

        stopGeneration = true;
    }
}
