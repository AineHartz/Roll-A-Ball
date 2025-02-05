using UnityEngine;

public class SpawnSpaceScript : MonoBehaviour, Clickable
{
    //Says which ball to spawn
    public GameObject ballPrefab;

    public void onClick(Vector3 hitPoint)
    {
        Instantiate(ballPrefab, hitPoint, Quaternion.identity);
    }
}
