using TMPro;
using UnityEngine;

public class Autodrop : MonoBehaviour, Clickable
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
        cost = 100000;
        display();
    }

    void display()
    {
        string currentSpeed = balls.getSpeedToString();
        string nextSpeed = balls.getNextMaxToString();
        text.text = "Autodrop: \n" + currentSpeed + " -> " + nextSpeed + "\nCost: " + points.formatNumber(cost);
    }

    public void onClick(Vector3 hitPoint)
    {
        if (cost <= points.getPoints())
        {
            points.buy(cost);

            if(balls.autodrop == false)
            {
                balls.toggleAutodrop();
            }

            else
            {
                balls.improveAutodrop();
            }

            cost = cost * 2;
            display();
        }
    }
}
