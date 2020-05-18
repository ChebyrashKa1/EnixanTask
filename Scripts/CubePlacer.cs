using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubePlacer : MonoBehaviour, IPointerClickHandler
{
    private MyGrid grid;
    public static GameObject pasteObj;
    public static bool place;
    bool canCreate;

    private void Awake()
    {
        place = false;
        pasteObj = null;
        grid = FindObjectOfType<MyGrid>();
    }

    private void Update()
    {
        if (place)//(Input.GetMouseButtonDown(0) && pasteObj != null)
        {
            place = false;

            //RaycastHit hitInfo;
            //Vector3 toScreen = Camera.main.WorldToScreenPoint(pasteObj.transform.position);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Camera.main.ScreenPointToRay(toScreen);//

            PlaceCubeNear(pasteObj.transform.position);
            //if (Physics.Raycast(ray, out hitInfo))
            //  PlaceCubeNear(hitInfo.point);
        }
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        InfoItem info = pasteObj.GetComponent<InfoItem>();
        float xCrat = 0, zCrat = 0;
        if (info.item.width % 2 == 0)
            xCrat = 0.5f;
        if (info.item.height % 2 == 0)
            zCrat = 0.5f;
        clickPoint -= new Vector3(xCrat, 0, zCrat);
        //Vector3 finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        //finalPosition = new Vector3(finalPosition.x, 1.0f, finalPosition.z);
        Debug.Log("finalPosition " + clickPoint + "| " + clickPoint);

        canCreate = CheckGridFree(info, clickPoint);
        if (canCreate)
        {
            //Debug.Log("Create not access!" + finalPosition);
            pasteObj.transform.position = new Vector3(clickPoint.x + xCrat, 0, clickPoint.z + zCrat);
            pasteObj.GetComponent<FollowMousePosition>().enabled = false;
            info.ColorSwap(Color.clear);
            MyGrid.DotsBlock(clickPoint, info.item.width, info.item.height, 1);
            pasteObj = null;
        }
        else
        {
            info.ColorSwap(Color.red);
            Debug.Log("Create not access!");
        }
    }

    bool CheckGridFree(InfoItem info, Vector3 position)
    {
        canCreate = false;
        int wMax = info.item.width;
        int hMax = info.item.height;
        int fpX = (int)position.x;
        int fpZ = (int)position.z;
        if (wMax % 2 != 0 && wMax != 1)
            fpX -= (int)((wMax - 1) * 0.5f);
        if (hMax % 2 != 0 && hMax != 1)
            fpZ -= (int)((hMax - 1) * 0.5f);

        Debug.Log("wMax: " + wMax + " hMax: " + hMax + " fpX: " + fpX + " fpZ: " + fpZ);

        for (int i = fpX; i < fpX + wMax; i++)
        {
            for (int z = fpZ; z < fpZ + hMax; z++)
            {
                if (MyGrid.gridMap[i, z] == 1)
                {
                    Debug.Log("notCreate false!: " + i + "|" + z + " = " + MyGrid.gridMap[i, z]);
                    canCreate = false;
                    return canCreate;
                }
                else
                {
                    Debug.Log("canCreate true! " + i + "|" + z + " = " + MyGrid.gridMap[i, z]);
                    canCreate = true;
                }
            }
        }
        return canCreate;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        /*if (pasteObj != null)
        {
            place = true;
            RaycastHit hitInfo;
            Vector3 toScreen = Camera.main.WorldToScreenPoint(pasteObj.transform.position);
            Ray ray = Camera.main.ScreenPointToRay(toScreen);//Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                PlaceCubeNear(hitInfo.point);
                pasteObj = null;
            }
        }*/
    }
}