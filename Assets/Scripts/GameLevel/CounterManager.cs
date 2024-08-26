using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CounterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject CounterObject;

    [SerializeField]
    private Text counterText;


    GameManager gameManager;


    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        StartCoroutine(CounterRoutine());
    }


    IEnumerator CounterRoutine()
    {
        counterText.text = "3";
        yield return new WaitForSeconds(0.5f);

        CounterObject.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        CounterObject.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        counterText.text = "2";

        yield return new WaitForSeconds(0.5f);

        CounterObject.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        CounterObject.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        counterText.text = "1";
        yield return new WaitForSeconds(0.5f);

        CounterObject.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        CounterObject.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        StopAllCoroutines();


        gameManager.StartGame();


    }


}
