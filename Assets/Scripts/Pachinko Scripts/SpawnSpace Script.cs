using UnityEngine;

public class SpawnSpaceScript : MonoBehaviour, Clickable
{
    //Says which ball to spawn
    public GameObject ballPrefab;

    //How fast balls are launched downwards on spawn
    float downwardForce = 2f;

    public void onClick(Vector3 hitPoint)
    {
        GameObject newBall = Instantiate(ballPrefab, hitPoint, Quaternion.identity);

        
        /*
         * The below lines of code handle the "bloom" effect. Meaning, when a ball is spawned, it doesn't go straight down, it spreads out a bit,
         * so every ball spawned at the same spot doesn't follow the same path. The rigidbody of the new ball is fetched, a small random number is generated,
         * and then a force vector is created that will make sure the ball always goes downward, but with a slight variation either way. Then, the forcevector is
         * applied to the ball's rigidbody. 
         */
        
        Rigidbody rb = newBall.GetComponent<Rigidbody>();
        float randomX = Random.Range(-2f, 2f);
        
        //The normalization makes sure that the downward force applied is consistent. 
        Vector3 forceVector = new Vector3(randomX, -1f, 0f).normalized * downwardForce;

        // VelocityChange makes the added force apply immediately. 
        rb.AddForce(forceVector, ForceMode.VelocityChange);
    }
}
