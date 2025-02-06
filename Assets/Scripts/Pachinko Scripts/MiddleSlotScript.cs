using UnityEngine;

public class MiddleSlotScript : MonoBehaviour
{
    //The middle slot specifically calls a slightly different method from PointHandler, as the middle slot has special modifiers applied. 
    
    public double basePoints;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            PointHandler.Instance.addMiddlePoints(basePoints);
            Destroy(other.gameObject);
        }
    }
}
