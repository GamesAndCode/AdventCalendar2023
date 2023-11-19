using EventChannel;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/ShopItemDefinition")]
public class ShopItemDefinition : ScriptableObject
{
    public ShopItemType shopItemType;
    public Sprite shopIcon;
    public string description;
    public BuyCondition buyCondition;
    public List<EmptyEventChannel> postEvents;
}

