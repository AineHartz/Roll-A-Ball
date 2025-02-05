using UnityEngine;

public class SlotScript : MonoBehaviour
{
    //Set in inspector. This is the base point value for each slot, before any multipliers are applied. 
    public int basePoints;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            Debug.Log("Detected ball! Points for this slot: " + basePoints);
            Destroy(other.gameObject);
        }
    }
}
