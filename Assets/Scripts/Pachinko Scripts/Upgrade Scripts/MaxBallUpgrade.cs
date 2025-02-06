using TMPro;
using UnityEngine;

public class MaxBallUpgrade : MonoBehaviour, Clickable
{
    private TMP_Text text;
    private double cost;
    BallHandler balls;
    PointHandler points;

    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        balls = BallHandler.Instance;
        points = PointHandler.Instance;
        cost = 200000;
        display();
    }

    void display()
    {
        string currentMax = balls.getMaxToString();
        string nextMax = balls.getNextMaxToString();
        text.text = "Max Balls: \n" + currentMax + " -> " + nextMax + "\nCost: " + points.formatNumber(cost);
    }

    public void onClick(Vector3 hitPoint)
    {
        if (cost <= points.getPoints())
        {
            points.buy(cost);
            balls.incrementMax();
            cost = cost * 2;
            display();
        }
    }
}
