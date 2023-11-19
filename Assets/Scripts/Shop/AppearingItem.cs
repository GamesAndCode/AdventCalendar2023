using EventChannel;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class AppearingItem : ShopableItem
{
    public UnityAction OnBuyed;
    
    public AppearingItem(BuyCondition buyCondition, List<EmptyEventChannel> postEvents) : base(buyCondition, postEvents)    {    }

    public override GameResources Buy()
    {
        OnBuyed?.Invoke();
        return base.Buy();
    }
}

