using UnityEngine;

public class SpawnSpaceScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Ball"))
        {
            Debug.Log("Clicking here works!");
        }
    }
}
