using TMPro;
using UnityEngine;

public class PointDisplay : MonoBehaviour
{
    private TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.text = PointHandler.Instance.getPointsToString();
    }
}
