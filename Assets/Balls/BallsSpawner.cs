using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsSpawner : MonoBehaviour
{
    [SerializeField] private Ball1 ballPrefab;
    [SerializeField] private Ball1[] balls;
    [SerializeField] private int numberOfBallsToSpawn;
    [SerializeField] private float spawnNextBallAfter;
    [SerializeField] private float spawnFirstBallAfter = 0.2f;
    private bool areBallsToActive = true;
    private float startSpawnNextBallAfter;

    private void Awake()
    {
        balls = new Ball1[numberOfBallsToSpawn];
        PoolBalls();
    }

    private void Start()
    {
        startSpawnNextBallAfter = spawnNextBallAfter;
        spawnNextBallAfter = spawnFirstBallAfter;
    }

    private void Update()
    {
        BallAcivationAfterTimeProcess();
    }

    private void BallAcivationAfterTimeProcess()
    {
        if (spawnNextBallAfter <= 0)
        {
            ActiveteBall();
            spawnNextBallAfter = startSpawnNextBallAfter;
        }
        else
        {
            spawnNextBallAfter -= Time.deltaTime;
        }
    }

    private void ActiveteBall()
    {
        if(areBallsToActive)
        {
            for (int i = 0; i < numberOfBallsToSpawn; i++)
            {
                if (balls[i].gameObject.active == false)
                {
                    balls[i].gameObject.SetActive(true);
                    return;
                }
            }

            areBallsToActive = false;
        }
    }

    private void PoolBalls()
    {
        for (int i = 0; i < numberOfBallsToSpawn; i++)
        {
            Ball1 ball = Instantiate(ballPrefab, transform.position, Quaternion.identity, transform);
            balls[i] = ball;
            balls[i].gameObject.SetActive(false);
        }
    }
}
