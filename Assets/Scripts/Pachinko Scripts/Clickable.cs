using UnityEngine;

//First time making an interface without being forced to! I made this so my click manager could just fetch the clickable component and call it's onClick method.

public interface Clickable
{
    void onClick(Vector3 hitPoint);
}
