using TMPro;
using UnityEngine;

public class PointMulti : MonoBehaviour, Clickable
{
    private TMP_Text text;
    private double cost;
    PointHandler points;

    //This class just reaches out to the PointHandler, calls it's multiplier method, and increases the cost of the upgrade. 

    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        cost = 200;
        points = PointHandler.Instance;
        display();
    }
 
    void display()
    {
        string currentMult = points.multiplierToString();
        string nextMult = points.nextMultiToString();
        text.text = "Point Multiplier: \n" + currentMult + " -> " + nextMult + "\nCost: " + points.formatNumber(cost);
    }

    public void onClick(Vector3 hitPoint)
    {
        if (cost <= points.getPoints())
        {
            points.buy(cost);
            points.multiplier();
            cost = cost * 200;
            display();
        }
    }
}
