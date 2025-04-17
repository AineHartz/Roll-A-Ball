using TMPro;
using UnityEngine;

public class WinScript : MonoBehaviour, Clickable
{
    private TMP_Text text;
    private double cost;
    PointHandler points;

    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        cost = 10000000;
        points = PointHandler.Instance;
        display();
    }
    void display()
    {
        text.text = "Beat the Game \n" + "\nCost: " + points.formatNumber(cost);
    }

    public void onClick(Vector3 hitPoint)
    {
        if (cost <= points.getPoints())
        {
            points.buy(cost);
            UnityEngine.SceneManagement.SceneManager.LoadScene("VictoryScene");
        }
    }
}
