using UnityEngine;

/*
 * This button is for cheating, basically, so that I don't have to wait to get to the part of the game I want to get to.
 * Gives you the middle slot's point value every time you click it. 
 */
public class DebugScript : MonoBehaviour, Clickable
{
    public void onClick(Vector3 hitPoint)
    {
        PointHandler.Instance.addMiddlePoints(250);
    }
}