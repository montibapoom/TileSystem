using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject prefab;
    private int buildHeight;
    private int buildWidth;
    private float prefabScale;

    private GameObject[,] instances;

    // Test
    public Rect GridRect
    {
        get
        {
            if (instances != null)
            {
                gridRect = new Rect()
                {
                    x = instances[0, 0].transform.position.x - prefabScale * .5f,
                    y = instances[0, 0].transform.position.y - prefabScale * .5f,
                    width = buildWidth * prefabScale,
                    height = buildHeight * prefabScale
                };
            }
            return gridRect;
        }
    }
    private Rect gridRect;

    //public void ShowCornerPosition()
    //{
    //    if (instances != null)
    //    {
    //        Debug.Log($"x:{instances[0, 0].transform.position.x - prefabScale * .5f}\ty:{instances[0, 0].transform.position.y - prefabScale * .5f}");
    //    }
    //}

    public void CreateBuilding(int buildHeight, int buildWidth, float prefabScale)
    {
        this.buildHeight = buildHeight;
        this.buildWidth = buildWidth;
        this.prefabScale = prefabScale;

        DestroyBuilding();

        if (buildHeight != 0 && buildWidth != 0)
        {
            instances = new GameObject[buildWidth, buildHeight];
            StartCoroutine(CreateBuilding(instances));
        }
    }

    public void DestroyBuilding()
    {
        if (instances != null)
        {
            StartCoroutine(DestroyBuilding(instances));
        }
    }

    private bool IsWidthEvenHorizontally => instances.GetLength(0) % 2 == 0;
    private bool IsHeightEvenVertically => instances.GetLength(1) % 2 == 0;

    private IEnumerator CreateBuilding(GameObject[,] instances)
    {
        var buildWidth = instances.GetLength(0);
        var buildHeight = instances.GetLength(1);

        var offset = new Vector2((buildWidth - 1) * .5f, (buildHeight - 1) * .5f);

        for (int i = 0; i < buildWidth; i++)
        {
            for (int j = 0; j < buildHeight; j++)
            {
                var instance = Instantiate(prefab, this.transform);

                var position = new Vector3((i - offset.x) * prefabScale, (j - offset.y) * prefabScale, 0);

                if (IsWidthEvenHorizontally)
                {
                    position += Vector3.right * prefabScale * .5f;
                }
                if (IsHeightEvenVertically)
                {
                    position += Vector3.up * prefabScale * .5f;
                }

                instance.transform.localPosition = position;
                instance.transform.localScale = Vector3.one * prefabScale;

                instances[i, j] = instance;

                yield return null;
            }
        }
    }

    private IEnumerator DestroyBuilding(GameObject[,] instances)
    {
        for (int i = 0; i < instances.GetLength(0); i++)
        {
            for (int j = 0; j < instances.GetLength(1); j++)
            {
                Destroy(instances[i, j]);

                yield return null;
            }
        }
    }
}
