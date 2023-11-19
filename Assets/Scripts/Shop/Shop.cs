using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ShopItemUI> doors;
    [SerializeField] private List<ShopItemController> doorPicture;
    [SerializeField] private List<DoorContentUI> doorContent;

    private IShopCustomer customer;

    public void Start()
    {
        if(doors.Count != doorPicture.Count || doorContent.Count != doorContent.Count)
        {
            Debug.LogError("Check your shop/calendar configuration. Doors, picutures and/or content is not equal!");
        }
        for (int i = 0; i < doors.Count; i++)
        {
            ShopItemUI door = doors[i];
            door.SetDescription((i + 1).ToString());
            if (i < doorPicture.Count)
            {
                ShopItemController picture = doorPicture[i];
                IShopable shopableItem = picture.GetShopItem();
                door.SetBuyButtonAction(() => {
                    TryBuyItem(shopableItem);
                    if (picture.IsBuyed) { door.isOpened(); }
                });
                door.SetDoorNumber(i + 1);
                if (picture.IsBuyed) { door.isOpened(); }
                UIImageHoverEffect imageHover = picture.GetComponent<UIImageHoverEffect>();
                imageHover.SetDoorContentUI(doorContent[i]);
            }
        }
    }

    public void TryBuyItem(IShopable shopableItem)
    {
        if (customer != null && shopableItem.IsBuyable(customer.GetOfferedResources()))
        {
            customer.GetOfferedResources().Subtract(shopableItem.Buy());
            customer.BoughtItem(shopableItem);
        }
        else
        {
            Debug.Log("Not enough resources");
        }
    }

    public void Show(IShopCustomer customer)
    {
        this.customer = customer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        customer = null;
        gameObject.SetActive(false);
    }
}
