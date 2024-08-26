using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text TimeText;

    int remainingTime;

    bool isContinue = true;


    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Start()
    {

        remainingTime = 90;
        isContinue = true;


    }


    public void StartTime()
    {


        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        while (isContinue)
        {
            yield return new WaitForSeconds(1f);

            if (remainingTime < 10)
            {
                TimeText.text = "0" + remainingTime.ToString();
            }
            else
            {
                TimeText.text = remainingTime.ToString();
            }

            if (remainingTime <= 0)
            {
                isContinue = false;
                TimeText.text = "";
                gameManager.FinishGame();

            }

            remainingTime--;
        }
    }


}
