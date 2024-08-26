using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Transform head;

    [SerializeField]
    private Transform startButton;


    void Start()
    {
        head.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
        startButton.transform.GetComponent<RectTransform>().DOLocalMoveY(-270f, 1f).SetEase(Ease.OutBack);
    }


    public void StartGame()
    {
        SceneManager.LoadScene("GameLevel");

    }


}
