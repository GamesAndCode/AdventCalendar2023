using System;
using UnityEngine;

[Serializable]
public struct GameResources
{
    [SerializeField] private int wood;
    [SerializeField] private int stone;
    [SerializeField] private int food;

    private int GetWood() => wood;
    private int GetStone() => stone;
    private int GetFood() => food;

    public bool IsPartcialQuanityOf(GameResources other)
    {
        return other.GetWood() >= wood && other.GetStone() >= stone && other.GetFood() >= food;
    }

    public void Subtract(GameResources other)
    {
        wood -= other.GetWood();
        stone -= other.GetStone();
        food -= other.GetFood();
    }

    public override string ToString()
    {
        return $"Wood: {wood},\r\nStone: {stone},\r\nFood: {food}";
    }
}
