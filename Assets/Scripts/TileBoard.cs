using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileBoard : MonoBehaviour
{
    [SerializeField]
    private Tile tilePrefab;
    [SerializeField]
    private Vector2Int size;

    private Tile[,] tiles;

    public static TileBoard Instance { get; private set; }

    //private Vector3 Offset => new Vector3((size.x - 1) * .5f, 0, (size.y - 1) * .5f);

    private void Start()
    {
        Instance = this;
    }

    public void CreateBoard(bool enableDebugText = false)
    {
        tiles = new Tile[size.x, size.y];

        for (int x = 0; x < tiles.GetLength(0); x++)
        {
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                var prefabPosition = new Vector3Int(x, 0, y);
                var prefab = Instantiate(tilePrefab, this.transform);
                prefab.transform.position = prefabPosition;// - Offset;

                if (enableDebugText)
                {
                    prefab.TextSetter.gameObject.SetActive(true);
                    prefab.TextSetter.SetText($"{x}{y}");
                }

                tiles[x, y] = prefab;
            }
        }
    }

    public bool TryToGetTile(RaycastHit hit, out Tile tile)
    {
        var roundedVector = Vector3Int.RoundToInt(hit.point);// + Offset);

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
        return x >= 0 && y >= 0 && size.x >= x && size.y >= y;
    }
}

public enum Axis
{
    Vertical,
    Horizontal
}