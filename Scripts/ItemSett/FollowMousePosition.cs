using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FollowMousePosition : MonoBehaviour, IDragHandler, IDropHandler, IEndDragHandler

{
    public float zValue;
    InfoItem info;
    void Start()
    {
        info = GetComponent<InfoItem>();
        Vector3 centerCamera = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
        transform.position = new Vector3(centerCamera.x + 7.5f, 0.0f, centerCamera.z + 7.5f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("drag");
        info.ColorSwap(Color.green);
        Vector3 temp = Input.GetTouch(0).position;
        temp.z = zValue;
        transform.position = Camera.main.ScreenToWorldPoint(temp);
        temp = transform.position;

        temp.x = Mathf.RoundToInt(temp.x / 1f) * 1f;
        temp.z = Mathf.RoundToInt(temp.z / 1f) * 1f;
        if (info.item.width % 2 == 0)
            temp.x += 0.5f;
        if (info.item.height % 2 == 0)
            temp.z += 0.5f;
        transform.position = new Vector3(temp.x, 0, temp.z);
    }

    public void OnDrop(PointerEventData eventData)
    {
        //   CubePlacer.place = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CubePlacer.place = true;
    }
}