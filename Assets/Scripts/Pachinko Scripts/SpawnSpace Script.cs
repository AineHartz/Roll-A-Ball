using UnityEngine;

public class SpawnSpaceScript : MonoBehaviour, Clickable
{
    public void onClick(Vector3 hitPoint)
    {
        BallHandler.Instance.createBall(hitPoint);
    }
}
