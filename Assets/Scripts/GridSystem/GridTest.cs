using TMPro;
using UnityEngine;

public class GridTest<T>
{
    // Mine
    public Rect GridRect
    {
        get
        {
            if (gridRect == Rect.zero)
            {
                gridRect = new Rect()
                {
                    x = originPosition.x,
                    y = originPosition.y,
                    width = width * cellSize,
                    height = height * cellSize
                };
            }
            return gridRect;
        }
    }
    private Vector3 OriginCells => originPosition * (1f / cellSize);
    private Vector2Int OriginOffset => new Vector2Int((int)OriginCells.x, (int)OriginCells.y);
    private Rect gridRect;
    //

    private TextMeshPro[,] debugTextArray;
    private T[,] gridArray;
    private Vector3 originPosition;
    private int width;
    private int height;
    private float cellSize;

    public GridTest(int width, int height, float cellSize, Vector3 originPosition = default, Transform parent = null, bool enableDebugMode = false)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new T[width, height];

        if (enableDebugMode)
            debugTextArray = new TextMeshPro[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                if (enableDebugMode)
                {
                    debugTextArray[x, y] = TextMeshBuilder.CreateText("World text", $"{gridArray[x, y]}")
                    .SetFontSize(cellSize * 10)
                    .SetLocalPosition(GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f)
                    .SetColor(Color.white)
                    .SetAlignment()
                    .SetParent(parent);

                }
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

        this.originPosition = originPosition;
    }

    public void SetValue(int x, int y, T value)
    {
        if (ValuesBetweenRange(x, y, width, height))
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].UpdateText(value.ToString());
        }
    }

    public void SetValue(Vector3 worldPosition, T value)
    {
        var index = GetXY(worldPosition);
        SetValue(index.x, index.y, value);
    }

    public void SetValuesInRect(Rect rect, T value)
    {
        var indexes = rect.GetIndexes(OriginOffset, cellSize);

        for (int x = 0; x < indexes.GetLength(0); x++)
        {
            for (int y = 0; y < indexes.GetLength(1); y++)
            {
                var index = indexes[x, y];

                SetValue(index.x, index.y, value);
            }
        }
    }

    public Vector3 GetCellPosition(Vector3 worldPosition)
    {
        var index = GetXY(worldPosition);

        return GetWorldPosition(index.x, index.y) + new Vector3(cellSize, cellSize) * .5f;
    }

    public T GetValue(int x, int y)
    {
        if (ValuesBetweenRange(x, y, width, height))
        {
            return gridArray[x, y];
        }

        return default;
    }

    public T GetValue(Vector3 worldPosition)
    {
        var vector = GetXY(worldPosition);

        return GetValue(vector.x, vector.y);
    }

    private bool ValuesBetweenRange(int x, int y, int width, int height)
    {
        return (x >= 0 && y >= 0 && x < width && y < height);
    }

    private Vector3 GetWorldPosition(int x, int y) => new Vector3(x, y) * cellSize + originPosition;
    private Vector2Int GetXY(Vector3 worldPosition)
    {
        //var floored = Vector3Int.FloorToInt((worldPosition - originPosition) / cellSize);
        var floored = Vector3Int.RoundToInt((worldPosition - originPosition) / cellSize);

        return new Vector2Int(floored.x, floored.y);
    }
}
