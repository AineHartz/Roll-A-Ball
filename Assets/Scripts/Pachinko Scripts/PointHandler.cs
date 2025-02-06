using UnityEngine;

public class PointHandler : MonoBehaviour
{
    //I remembered singleton pattern was a thing! The below line allows for an instance of PointHandler that can be accesed (but not modified)
    //by any other scripts. 
    public static PointHandler Instance { get; private set; }

    public double totalPoints = 0;
    public double pointMulti = 1;

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

    public void addPoints(double basePoints)
    {
        double finalPoints = basePoints * pointMulti;
        totalPoints += finalPoints;
    }

    //A method for buying an upgrade, which subtracts the cost from total points.
    public void buy(double cost)
    {
        totalPoints -= cost;
    }

    //Mixed scientific notation. If the number is over 1e4, make it scientific notation. 
    public string formatNumber(double number)
    {
        if(number >= 10000)
        {
            return number.ToString("0.00e0");
        }

        else
        {
            return number.ToString();
        }
    }

    public double getPoints()
    {
        return totalPoints;
    }

    public string getPointsToString()
    {
        return "Points: " + formatNumber(totalPoints);
    }

    public void multiplier()
    {
        pointMulti = pointMulti * 5;
    }

    public string multiplierToString()
    {
        return formatNumber(pointMulti);
    }

    public string nextMultiToString()
    {
        return formatNumber(pointMulti * 5);
    }
}
