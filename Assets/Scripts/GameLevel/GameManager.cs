using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject markTimePanel;

    [SerializeField]
    private GameObject pausePanel, resultPanel;


    [SerializeField]
    private GameObject takePointText, selectBigNumberText;

    [SerializeField]
    private GameObject upperRectangle, underRectangle;

    [SerializeField]
    private Text upperText, lowerText, pointText;


    TimerManager timerManager;
    CircleManager circleManager;
    TrueFalseManager trueFalseManager;
    ResultManager resultManager;



    int gameCounter, currentGame;

    int upperValue, lowerValue;

    int greaterValue;

    int buttonValue;

    int sumPoint, incPoint;

    int correctCount, wrongCount;


    private AudioSource audioSource;

    [SerializeField]
    private AudioClip startAudioClip, correctAudioClip, wrongAudioClip, endingAudioClip;

    private void Awake()
    {
        timerManager = Object.FindObjectOfType<TimerManager>();
        circleManager = Object.FindObjectOfType<CircleManager>();
        trueFalseManager = Object.FindObjectOfType<TrueFalseManager>();

        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        currentGame = 0;
        gameCounter = 0;

        sumPoint = 0;




        upperText.text = "";
        lowerText.text = "";
        pointText.text = "0";

        UpdateScreen();
    }

    void UpdateScreen()
    {
        markTimePanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        takePointText.GetComponent<CanvasGroup>().DOFade(1, 1f);

        upperRectangle.GetComponent<RectTransform>().DOLocalMoveX(0, 0.7f).SetEase(Ease.OutBack);
        underRectangle.GetComponent<RectTransform>().DOLocalMoveX(0, 0.7f).SetEase(Ease.OutBack);

     
    }

    public void StartGame()
    {
        audioSource.PlayOneShot(startAudioClip);


        takePointText.GetComponent<CanvasGroup>().DOFade(0, 1f);

        selectBigNumberText.GetComponent<CanvasGroup>().DOFade(1, 1f);




        CurrentGame();

        timerManager.StartTime();



    }

    void CurrentGame()
    {
        if (gameCounter < 5)
        {
            currentGame = 1;
            incPoint = 25;
        }
        else if (gameCounter >= 5 && gameCounter < 10)
        {
            currentGame = 2;
            incPoint = 50;
        }
        else if (gameCounter >= 10 && gameCounter < 15)
        {
            currentGame = 3;
            incPoint = 75;
        }
        else if (gameCounter >= 15 && gameCounter < 20)
        {
            currentGame = 4;
            incPoint = 100;
        }
        else if (gameCounter >= 20 && gameCounter < 25)
        {
            currentGame = 5;
            incPoint = 125;
        }
        else
        {
            currentGame = Random.Range(1, 6);
            incPoint = 150;
        }

        switch (currentGame)
        {
            case 1:
                FirstFunc();
                break;

            case 2:
                SecondFunc();
                break;

            case 3:
                ThirdFunc();
                break;

            case 4:
                FourthFunc();
                break;

            case 5:
                FifthFunc();
                break;

        }
    }

    void FirstFunc()
    {
        int randomValue = Random.Range(1, 50);

        if (randomValue <= 25)
        {
            upperValue = Random.Range(2, 50);
            lowerValue = upperValue + Random.Range(1, 15);
        }
        else
        {
            upperValue = Random.Range(2, 50);
            lowerValue = Mathf.Abs(upperValue - Random.Range(1, 15));
        }

        if (upperValue > lowerValue)
        {
            Debug.Log("yukarı buyuk");
            greaterValue = upperValue;
        }
        else if (upperValue < lowerValue)
        {
            Debug.Log("asagı buyuk");
            greaterValue = lowerValue;
        }

        if (upperValue == lowerValue)
        {
            FirstFunc();
            return;
        }

        upperText.text = upperValue.ToString();
        lowerText.text = lowerValue.ToString();



    }

    void SecondFunc()
    {
        int firstNumber = Random.Range(1, 10);
        int secondNumber = Random.Range(1, 20);

        int thirdNumber = Random.Range(1, 10);
        int fourthSayi = Random.Range(1, 20);

        upperValue = firstNumber + secondNumber;
        lowerValue = thirdNumber + fourthSayi;

        if (upperValue > lowerValue)
        {
            greaterValue = upperValue;
        }
        else if (upperValue < lowerValue)
        {
            greaterValue = lowerValue;
        }

        if (upperValue == lowerValue)
        {
            SecondFunc();
            return;
        }

        upperText.text = firstNumber + "+" + secondNumber;
        lowerText.text = thirdNumber + "+" + fourthSayi;

    }

    void ThirdFunc()
    {
        int firstNumber = Random.Range(11, 30);
        int secondNumber = Random.Range(1, 11);

        int thirdNumber = Random.Range(11, 40);
        int fourthSayi = Random.Range(1, 11);

        upperValue = firstNumber - secondNumber;
        lowerValue = thirdNumber - fourthSayi;

        if (upperValue > lowerValue)
        {
            greaterValue = upperValue;
        }
        else if (upperValue < lowerValue)
        {
            greaterValue = lowerValue;
        }

        if (upperValue == lowerValue)
        {
            ThirdFunc();
            return;
        }

        upperText.text = firstNumber + "-" + secondNumber;
        lowerText.text = thirdNumber + "-" + fourthSayi;

    }

    void FourthFunc()
    {
        int firstNumber = Random.Range(1, 10);
        int secondNumber = Random.Range(1, 10);

        int thirdNumber = Random.Range(1, 10);
        int fourthSayi = Random.Range(1, 10);

        upperValue = firstNumber * secondNumber;
        lowerValue = thirdNumber * fourthSayi;

        if (upperValue > lowerValue)
        {
            greaterValue = upperValue;
        }
        else if (upperValue < lowerValue)
        {
            greaterValue = lowerValue;
        }

        if (upperValue == lowerValue)
        {
            FourthFunc();
            return;
        }

        upperText.text = firstNumber + " x " + secondNumber;
        lowerText.text = thirdNumber + " x " + fourthSayi;


    }

    void FifthFunc()
    {
        int divider1 = Random.Range(2, 10);
        upperValue = Random.Range(2, 10);

        int bolunen1 = divider1 * upperValue;


        int divider2 = Random.Range(2, 10);
        lowerValue = Random.Range(2, 10);

        int bolunen2 = divider2 * lowerValue;

        if (upperValue > lowerValue)
        {
            greaterValue = upperValue;
        }
        else if (upperValue < lowerValue)
        {
            greaterValue = lowerValue;
        }

        if (upperValue == lowerValue)
        {
            FifthFunc();
            return;
        }

        upperText.text = bolunen1 + " / " + divider1;
        lowerText.text = bolunen2 + " / " + divider2;

    }
    public void SetButtonValue(bool isupper)
    {
        if (isupper)
        {
            buttonValue = upperValue;
           
        }
        else  
        {
           
            buttonValue = lowerValue;
        }
   
        if (buttonValue == greaterValue)
        {

            trueFalseManager.TrueFalseScaleopen(true);

            circleManager.CircleScaleOpen(gameCounter % 5);
            gameCounter++;
            sumPoint += incPoint;

            pointText.text = sumPoint.ToString();

            correctCount++;

            audioSource.PlayOneShot(correctAudioClip);

            CurrentGame();


        }
        else
        {
            trueFalseManager.TrueFalseScaleopen(false);
            DecreaseCounterByWrong();



            wrongCount++;

            audioSource.PlayOneShot(wrongAudioClip);
            CurrentGame();
        }
    }

    void DecreaseCounterByWrong()
    {
        gameCounter -= (gameCounter % 5 + 5);

        if (gameCounter < 0)
        {
            gameCounter = 0;
        }


        circleManager.CircleScaleClose();
    }



    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
    }



    public void FinishGame()
    {

        audioSource.PlayOneShot(endingAudioClip);

        resultPanel.SetActive(true);

        resultManager = Object.FindObjectOfType<ResultManager>();



        resultManager.GetResult(correctCount, wrongCount, sumPoint);


    }



}
