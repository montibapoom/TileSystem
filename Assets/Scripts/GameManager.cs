using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public Ray CameraRay => Camera.main.ScreenPointToRay(Input.mousePosition);

    private Tile selectedTile;

    private void Start()
    {
        TileBoard.Instance.CreateBoard(enableDebugText: true);
    }

    private void Update()
    {

        if (TileBoard.Instance.TryToGetTile(CameraRay, out selectedTile))
        {
        }
    }

    private void OnDrawGizmos()
    {
        if (selectedTile != null)
        {
            var tilePos = selectedTile.InboardPosition;
            var pos = new Vector3(tilePos.x, 0, tilePos.y);

            Debug.Log(tilePos);

            Gizmos.DrawWireSphere(pos, .5f);
        }
    }
}
