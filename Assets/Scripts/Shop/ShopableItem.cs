using EventChannel;
using System.Collections.Generic;

public abstract class ShopableItem : IShopable
{
    protected BuyCondition buyCondition;
    protected List<EmptyEventChannel> postEvents;

    public ShopableItem(BuyCondition buyCondition, List<EmptyEventChannel> postEvents)
    {
        this.buyCondition = buyCondition;
        this.postEvents = postEvents;
    }

    public virtual GameResources Buy()
    {
        foreach (EmptyEventChannel eec in postEvents)
        {
            eec.Invoke(new EmptyEvent());
        }
        return buyCondition.GetCosts();
    }
    public virtual bool IsBuyable(GameResources offeredResources)
    {
        return buyCondition.IsBuyable(offeredResources);
    }
}
