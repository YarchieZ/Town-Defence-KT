using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CoinCllicker : MonoBehaviour
{
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private int incomePerClick;
    [SerializeField] private float fillPerClick;
    [SerializeField] private Image image;
    private Button _button;
    private Vector3 _initialScale;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClickEvent);
        _initialScale = image.transform.localScale;

    }

    private void OnClickEvent()
    {
        image.transform.DOKill();
        image.transform.localScale = _initialScale;
        image.transform.DOPunchScale(
            Vector3.one * (1.1f - 1f),
            0.5f,
            2,
            0.5f
        );
        if (image.fillAmount >= 1)
        {
            image.fillAmount = 0;
            resourceManager.AddCoins(incomePerClick);
        }
        else
        {
            image.fillAmount += fillPerClick;
            
        }
        
    }
    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }
}
