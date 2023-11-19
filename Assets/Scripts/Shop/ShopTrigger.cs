using UnityEngine;
using UnityEngine.EventSystems;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private Shop shop;
    [SerializeField] private Player player;

    private void Awake()
    {
        shop.Show(player);
    }

}