using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody rb;
    private float timer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        /*
         * The below script is to help the ball self-correct if it gets stuck. If the ball's speed drops too low for too long, a small horizontal
         * force is applied to get it moving again. 
         */
        if (rb.linearVelocity.magnitude < 0.1f)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5f)
            {
                Vector3 nudgeDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
                rb.AddForce(nudgeDirection * 2f, ForceMode.Impulse);
                timer = 0f;
            }
        }

        else
        {
            timer = 0f;
        }
    }
}
