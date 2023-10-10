using UnityEngine;

public static class Vector3Extensions
{
    public static Vector2Int ConvertPlacementWithAxis(this Vector3Int position, Axis axis)
    {
        var resultVector = Vector2Int.zero;

        if (axis == Axis.Vertical)
            resultVector = new Vector2Int(position.x, position.y);
        else if (axis == Axis.Horizontal)
            resultVector = new Vector2Int(position.x, position.z);
        else
            Debug.LogWarning($"{axis.GetType()} doesn't exist");

        return resultVector;
    }

    public static Vector3Int FloorToInt(this Vector3 vector3)
    {
        return Vector3Int.FloorToInt(vector3);
    }
}
