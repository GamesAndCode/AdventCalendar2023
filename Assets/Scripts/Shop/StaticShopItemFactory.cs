public static class StaticShopItemFactory
{
    public static IShopable Create(ShopItemDefinition definition)
    {
        return definition switch
        {
            { shopItemType: ShopItemType.Appearing } => new AppearingItem(definition.buyCondition, definition.postEvents),
            _ => throw new System.NotImplementedException(),
        };
    }
}

