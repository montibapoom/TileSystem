using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Mine
    public int width = 3;
    public int height = 3;
    public float cellSize = 10f;
    public GameObject prefab;
    public Building buildingPrefab;
    private Vector3 MouseWorldPosition => Utils.GetMouseWorldPosition();
    //

    private GridTest<int> grid;

    private GameObject instance;
    private Building buildingInstance;

    private void Start()
    {
        var offset = new Vector3(0, 0);
        var gridWidth = 10;
        var gridHeight = 10;
        var cellSize = 10f;

        grid = new GridTest<int>(gridWidth, gridHeight, cellSize, offset, this.transform, true);

        instance = Instantiate(prefab);
        instance.transform.localScale = Vector3.one * cellSize;

        buildingInstance = Instantiate(buildingPrefab);
        buildingInstance.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //grid.SetValue(MouseWorldPosition, 34);
            var gridRect = grid.GridRect;
            var buildingRect = buildingInstance.GridRect;

            if (gridRect.Contains(buildingRect))
            {
                grid.SetValuesInRect(buildingRect, 34);
                Debug.Log($"Building in rect: {gridRect.Contains(buildingRect)}");
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            var value = grid.GetValue(MouseWorldPosition);
            Debug.Log(value);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            buildingInstance.gameObject.SetActive(true);
            buildingInstance.CreateBuilding(width, height, cellSize);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            buildingInstance.DestroyBuilding();
        }

        if (grid.GridRect.Contains(MouseWorldPosition))
        {
            instance.SetActive(true);
            var cellPosition = grid.GetCellPosition(MouseWorldPosition);
            instance.transform.position = cellPosition;

            buildingInstance.transform.localPosition = cellPosition;
            //buildingInstance.ShowCornerPosition();
            //Debug.Log(buildingInstance.GridRect);
            DrawUtils.DrawRect(buildingInstance.GridRect, Color.red);
        }
        else
        {
            instance.SetActive(false);
        }

        Debug.Log(buildingInstance.GridRect);
    }

    private void DebugInfor(params object[] log)
    {
        var sb = new StringBuilder();

        foreach (var item in log)
        {
            sb.AppendLine($"{nameof(item)}\t{item.ToString()}");
        }

        Debug.Log(sb.ToString());
    }

    private void OnDrawGizmos()
    {
        if (grid != null)
        {
            var position = grid.GridRect.Contains(MouseWorldPosition) ?
                grid.GetCellPosition(MouseWorldPosition) :
                MouseWorldPosition;

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(position, 5f);
        }
    }
}
