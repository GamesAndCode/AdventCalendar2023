using UnityEngine;

public class Player : MonoBehaviour, IShopCustomer
{
    [SerializeField] private GameResources resources;

    public void BoughtItem(IShopable shopableItem)
    {
        Debug.Log("Player bought " + shopableItem.ToString());
    }

    public GameResources GetOfferedResources()
    {
        return resources;
    }
}