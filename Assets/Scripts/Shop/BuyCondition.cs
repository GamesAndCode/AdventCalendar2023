using System.Collections.Generic;
using UnityEngine;
using EventChannel;

[CreateAssetMenu(menuName = "Shop/BuyCondition")]
public class BuyCondition : ScriptableObject
{
    [SerializeField] private GameResources costs;
    [SerializeField] private List<EmptyEventChannel> events;

    public GameResources GetCosts() => costs;
    public bool IsBuyable(GameResources offeredResources)
    {
        bool buyable = true;
        foreach(EmptyEventChannel emptyEventChannel in events)
        {
            buyable &= emptyEventChannel.IsInvoked();
        }
        buyable &= costs.IsPartcialQuanityOf(offeredResources);
        return buyable;
    }
}