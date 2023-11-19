using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class ShopItemUI : MonoBehaviour
{
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (description != null) { description.text = Regex.Replace(gameObject.name, "[^0-9]", ""); }
    }
#endif

    [SerializeField] private Image shopIcon;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI buyCondition;
    [SerializeField] private Button buyButton;
    public void SetShopIcon(Sprite icon) => shopIcon.sprite = icon;
    public void SetDescription(string description) => this.description.text = description;
    public void SetPrice(BuyCondition buyCondition)
    {
        this.buyCondition.text = "Price: " + buyCondition.GetCosts().ToString();
    }
    public void SetBuyButtonAction(Action value) => buyButton.onClick.AddListener(() => value());

    public void SetDoorNumber(int doorNumber) => buyButton.GetComponent<TimeBasedButton>()?.SetDoorNumber(doorNumber);

    public void isOpened()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}