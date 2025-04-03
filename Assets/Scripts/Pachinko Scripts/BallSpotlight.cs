using UnityEngine;

public class FollowBallFlat : MonoBehaviour
{
    private Transform ball;
    public float fixedZ = 0.5f;
    public Quaternion fixedRotation = Quaternion.identity;

    void Start()
    {
        ball = transform.parent;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(ball.position.x, ball.position.y, fixedZ);
        transform.rotation = fixedRotation;
    }
}