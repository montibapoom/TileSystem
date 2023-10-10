using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileBoard : MonoBehaviour
{
    public Tile tilePrefab;
    public Vector2Int boardSize;

    private Tile[,] tiles;

    public static TileBoard Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    public void CreateBoard()
    {
        tiles = new Tile[boardSize.x, boardSize.y];

        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                var prefabPosition = new Vector3Int(i, 0, j);
                var prefab = Instantiate(tilePrefab, this.transform);
                prefab.transform.position = prefabPosition;

                tiles[i, j] = prefab;
            }
        }
    }

    public bool TryToGetTile(RaycastHit hit, out Tile tile)
    {
        var roundedVector = Vector3Int.FloorToInt(hit.point);
        Debug.Log($"Rounded vector {roundedVector}");
        tile = null;

        if (HasTileAtIndex(roundedVector.x, roundedVector.z))
        {
            tile = tiles[roundedVector.x, roundedVector.z];
            return true;
        }

        return false;
    }

    public bool TryToGetTile(Ray ray, out Tile tile)
    {
        tile = null;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return TryToGetTile(hit, out tile);
        }

        return false;
    }

    private bool HasTileAtIndex(int x, int y)
    {
        return x >= 0 && y >= 0 && boardSize.x >= x && boardSize.y >= y;
    }
}

public enum Axis
{
    Vertical,
    Horizontal
}