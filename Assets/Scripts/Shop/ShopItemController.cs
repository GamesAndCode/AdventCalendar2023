using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ShopItemController : MonoBehaviour
{
    [SerializeField] private ShopItemDefinition shopItemDefinition;
    [SerializeField] private AudioClip appearingSound;
    private IShopable shopItem;
    public bool IsBuyed {get; private set;}

    private void Awake()
    {
        IsBuyed = PlayerPrefs.GetItemState(gameObject.name);
    }

    public IShopable GetShopItem()
    {
        if (shopItem == null)
        {
            shopItem = StaticShopItemFactory.Create(shopItemDefinition);
            if (shopItem is AppearingItem)
            {
                AppearingItem appearingItem = (AppearingItem)shopItem;
                appearingItem.OnBuyed += () => OnBuyed();
                gameObject.SetActive(IsBuyed);
            }
        }
        return shopItem;
    }

    private void OnBuyed()
    {
        if (!IsBuyed)
        {
            IsBuyed = true;
            PlayerPrefs.SetItemState(gameObject.name, IsBuyed);
            GetComponent<UIImageHoverEffect>().enabled = false;
            gameObject.transform.localScale = Vector3.zero;
            gameObject.SetActive(true);
            gameObject.LeanScale(Vector3.one, 0.5f).setEaseOutBack().setOnComplete(() =>
            {
                GetComponent<UIImageHoverEffect>().enabled = true;
            });
            if (appearingSound != null)
            {
                GetComponent<AudioSource>()?.PlayOneShot(appearingSound);
            }
        }
    }

    public ShopItemDefinition GetShopItemDefinition() => shopItemDefinition;
}
