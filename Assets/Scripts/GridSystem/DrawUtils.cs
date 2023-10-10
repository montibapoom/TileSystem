using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DrawUtils
{
    public static void DrawRect(Rect rect, Color color)
    {
        var startPosition = new Vector3(rect.x, rect.y, 0);
        var endPositionHorizontal = startPosition + Vector3.right * rect.width;
        var endPositionVertical = startPosition + Vector3.up * rect.height;

        Debug.DrawLine(startPosition, endPositionHorizontal, color);
        Debug.DrawLine(startPosition, endPositionVertical, color);
    }
}
