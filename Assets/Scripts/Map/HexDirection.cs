using UnityEngine;


public enum HexDirection
{
     NE, E, SE, SW, W, NW
}
public static class HexDirectionExtensions   //получение противоположной клитки
{

    public static HexDirection Opposite(this HexDirection direction)
    {
        return (int)direction < 3 ? (direction + 3) : (direction - 3);
    }
}