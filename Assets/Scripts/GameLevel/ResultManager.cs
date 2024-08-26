using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private Text correctCountText, wrongCountText, pointText;


    int pointTime = 10;
    bool isOverTime = true;

    int sumPoint, writeToPoint , addPoint;


    private void Awake()
    {
        isOverTime = true;
    }

    public void GetResult(int correctCount, int wrongCount, int point)
    {
        correctCountText.text = correctCount.ToString();
        wrongCountText.text = wrongCount.ToString();
        pointText.text = point.ToString();

        sumPoint = point;
        addPoint = sumPoint / 10;

        StartCoroutine(WritePointRoutine());
    }

    IEnumerator WritePointRoutine()
    {
        while (isOverTime)
        {
            yield return new WaitForSeconds(0.1f);

            writeToPoint += addPoint;

            if (writeToPoint >= sumPoint)
            {
                writeToPoint = sumPoint;
            }

            pointText.text = writeToPoint.ToString();


            if (pointTime <= 0)
            {
                isOverTime = false;
            }

            pointTime--;
        }
    }


    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuLevel");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameLevel");
    }




}
