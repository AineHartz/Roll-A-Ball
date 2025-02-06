using UnityEngine;

public class PointHandler : MonoBehaviour
{
    //I remembered singleton pattern was a thing! The below line allows for an instance of PointHandler that can be accesed (but not modified)
    //by any other scripts. 
    public static PointHandler Instance { get; private set; }

    public double totalPoints = 0;

    //Forces singleton. If another copy exists, destroy it first. 
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            Instance = this;
        }
    }

    public void addPoints(int basePoints)
    {
        totalPoints += basePoints;
    }

    //Mixed scientific notation. If the number is over 1e4, make it scientific notation. 
    public string formatPoints(double points)
    {
        if(points >= 10000)
        {
            return points.ToString("0.00e0");
        }

        else
        {
            return points.ToString();
        }
    }

    public string getPoints()
    {
        return "Points: " + formatPoints(totalPoints);
    }
}
