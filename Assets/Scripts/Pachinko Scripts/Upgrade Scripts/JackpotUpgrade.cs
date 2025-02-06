using TMPro;
using UnityEngine;

public class JackpotUpgrade : MonoBehaviour, Clickable
{
    private TMP_Text text;
    private double cost;
    PointHandler points;

    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        cost = 100;
        points = PointHandler.Instance;
        display();
    }
    void display()
    {
        string currentMult = points.middleMultiplierToString();
        string nextMult = points.middleNextMultiToString();
        text.text = "Center Slot Multiplier: \n" + currentMult + " -> " + nextMult + "\nCost: " + points.formatNumber(cost);
    }

    public void onClick(Vector3 hitPoint)
    {
        if (cost <= points.getPoints())
        {
            points.buy(cost);
            points.middleMultiplier();
            cost = cost * 5;
            display();
        }
    }
}
