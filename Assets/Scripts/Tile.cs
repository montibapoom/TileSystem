using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    public Tile north;
    public Tile south;
    public Tile west;
    public Tile east;

    public Vector2Int InboardPosition => this.transform.position.FloorToInt().ConvertPlacementWithAxis(Axis.Horizontal);

    public void OnPointerClick(PointerEventData eventData)
    {
    }
}

public static class TileExtensions
{
    public static void MakeSouthNeighbour(this Tile tile, Tile south)
    {
        tile.south = south;
        south.north = tile;
    }

    public static void MakeNorthNeighbour(this Tile tile, Tile north)
    {
        tile.north = north;
        north.south = tile;
    }

    public static void MakeEastNeighbour(this Tile tile, Tile east)
    {
        tile.east = east;
        east.west = tile;
    }

    public static void MakeWestNeighbour(this Tile tile, Tile west)
    {
        tile.west = west;
        west.east = tile;
    }
}