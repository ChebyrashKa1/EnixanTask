using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGrid : MonoBehaviour
{
    [SerializeField]
    private float size = 1f;
    [SerializeField]
    private static int lenghtField = 20;
    public GameObject gridDraw;

    public static int[,] gridMap = new int[lenghtField, lenghtField];

    void Awake()
    {
        for (int x = 0; x < lenghtField; x++)
        {
            for (int z = 0; z < lenghtField; z++)
                gridMap[x, z] = 0;
        }
    }

    public static void DotsBlock(Vector3 position, int width, int height, int gridValue)
    {
        int fpX = (int)position.x;
        int fpZ = (int)position.z;
         if (width % 2 != 0 && width != 1)
            fpX -= (int)((width - 1) * 0.5f);
        if (height % 2 != 0 && height != 1)
            fpZ -= (int)((height - 1) * 0.5f);

        for (int x = fpX; x < fpX + width; x++)
        {
            for (int z = fpZ; z < fpZ + height; z++)
            {
                gridMap[x, z] = gridValue;
                Debug.Log("Block: " + x + "|" + z + " = " + gridMap[x, z]);
            }
        }
    }

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3(
            (float)xCount * size,
            (float)yCount * size,
            (float)zCount * size);

        result += transform.position;

        return result;
    }

    public void GridShow()
    {
        gridDraw.SetActive(!gridDraw.activeSelf);
    }
    /* private void OnDrawGizmosSelected() //OnDrawGizmosSelected OnDrawGizmos
    {
        Debug.Log("giz");
        Gizmos.color = Color.green;
        for (float x = 0; x < lenghtField; x += size)
        {
            for (float z = 0; z < lenghtField; z += size)
            {
                Vector3 point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }*/
}