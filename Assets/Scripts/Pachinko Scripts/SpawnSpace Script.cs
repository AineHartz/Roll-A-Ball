using UnityEngine;

public class SpawnSpaceScript : MonoBehaviour, Clickable
{
    public void onClick(Vector3 hitPoint)
    {
        if (BallHandler.Instance.autodrop)
        {
            BallHandler.Instance.SetAutodropPoint(hitPoint);
        }

        else
        {
            BallHandler.Instance.createBall(hitPoint);
        }
    }
}
