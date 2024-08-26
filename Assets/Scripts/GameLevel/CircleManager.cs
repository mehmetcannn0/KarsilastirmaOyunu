using DG.Tweening;
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] circleArray;



    void Start()
    {
        CircleScaleClose();
    }

    public void CircleScaleClose()
    {
        foreach (GameObject circle in circleArray)
        {
            circle.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }


    public void CircleScaleOpen(int currentCircle)
    {
        circleArray[currentCircle].GetComponent<RectTransform>().DOScale(1, 0.3f);

        if (currentCircle % 5 == 0)
        {
            CircleScaleClose();
        }
    }

}
