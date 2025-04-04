using UnityEngine;

public class SlotScript : MonoBehaviour
{
    //Set in inspector. This is the base point value for each slot, before any multipliers are applied. 
    public double basePoints;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            PointHandler.Instance.addPoints(basePoints);
            BallHandler.Instance.destroyBall(other.gameObject);
            GetComponent<AudioSource>().Play();
        }
    }
}
