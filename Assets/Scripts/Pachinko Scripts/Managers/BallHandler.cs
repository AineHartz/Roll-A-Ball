using System;
using UnityEngine;

//Another singleton class, since I wanted to keep track of spawned balls. Copied some code from PointHandler.
public class BallHandler : MonoBehaviour
{
    //Says which ball to spawn
    public GameObject ballPrefab;

    //How fast balls are launched downwards on spawn
    float downwardForce = 2f;

    public int maxBalls;
    public int currentBalls;
    public Boolean autodrop;
    public float autodropSpeed;

    public static BallHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        maxBalls = 1;
        currentBalls = 0;
        autodrop = false;
        autodropSpeed = 1f;
    }

    //All of this code was stolen from SpawnSpace script
    public void createBall(Vector3 hitPoint)
    {
        if (currentBalls < maxBalls)
        {
            GameObject newBall = Instantiate(ballPrefab, hitPoint, Quaternion.identity);
            currentBalls++;

            /*
             * The below lines of code handle the "bloom" effect. Meaning, when a ball is spawned, it doesn't go straight down, it spreads out a bit,
             * so every ball spawned at the same spot doesn't follow the same path. The rigidbody of the new ball is fetched, a small random number is generated,
             * and then a force vector is created that will make sure the ball always goes downward, but with a slight variation either way. Then, the forcevector is
             * applied to the ball's rigidbody. 
             */

            Rigidbody rb = newBall.GetComponent<Rigidbody>();
            float randomX = UnityEngine.Random.Range(-4f, 4f);

            //The normalization makes sure that the downward force applied is consistent. 
            Vector3 forceVector = new Vector3(randomX, -1f, 0f).normalized * downwardForce;

            // VelocityChange makes the added force apply immediately. 
            rb.AddForce(forceVector, ForceMode.VelocityChange);
        }
    }

    public void destroyBall(GameObject ball)
    {
        Destroy(ball);
        currentBalls--;
    }

    public void incrementMax()
    {
        maxBalls++;
    }

    public string getMaxToString()
    {
        return ("" + maxBalls);
    }

    public string getNextMaxToString()
    {
        return ("" + (maxBalls + 1));
    }

    public string getSpeedToString()
    {
        return ("0.00" + autodropSpeed);
    }

    public string getNextSpeedToString()
    {
        return ("0.00" + (autodropSpeed * 0.9));
    }

    //It's a toggle, so this method just inverses the autodrop boolean. 
    public void toggleAutodrop()
    {
        autodrop = !autodrop;
    }

    public void improveAutodrop()
    {
        autodropSpeed = (autodropSpeed * 0.9f);
    }
}