using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class RectExtensions
{
    public static bool Contains(this Rect rect, Rect other)
    {
        return rect.xMin <= other.xMin && rect.yMin <= other.yMin
            && rect.xMax >= other.xMax && rect.yMax >= other.yMax;
    }

    public static Vector2Int[,] GetIndexes(this Rect rect, Vector2Int offset, float cellSize)
    {
        var startIndexX = (int)(rect.x / cellSize) - offset.x;
        var startIndexY = (int)(rect.y / cellSize) - offset.y;
        var stepsX = (int)(rect.width / cellSize);
        var stepsY = (int)(rect.height / cellSize);

        var vector = new Vector2Int[stepsX, stepsY];

        for (int x = 0; x < stepsX; x++)
        {
            for (int y = 0; y < stepsY; y++)
            {
                vector[x, y] = new Vector2Int(x + startIndexX, y + startIndexY);
            }
        }

        return vector;
    }
}