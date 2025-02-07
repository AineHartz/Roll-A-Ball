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
        string nextSpeed = balls.getNextSpeedToString();

        if (balls.autodrop == false)
        {
            text.text = "Autodrop \n" + "Cost: " + points.formatNumber(cost);
        }

        else
        {
            text.text = "Autodrop Delay: \n" + currentSpeed + "s -> " + nextSpeed + "s\nCost: " + points.formatNumber(cost);
        }
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
