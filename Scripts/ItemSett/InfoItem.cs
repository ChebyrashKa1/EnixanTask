using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoItem : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public Item item;
    public static Tooltip tooltip;
    MeshRenderer meshRenderer;
    Transform son;
    float timeTouch = 0;
    FollowMousePosition follow;

    void Awake()
    {
        item = ClickStore.itemToAdd;
        tooltip = GameObject.Find("TextTooltip").GetComponent<Tooltip>();
        follow = GetComponent<FollowMousePosition>();
        if (transform.childCount > 0)
        {
            son = transform.GetChild(0);
            meshRenderer = son.GetComponent<MeshRenderer>();
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
        {
            Debug.Log("click1: " + this.item.id + " name: " + gameObject.name);
            tooltip.GenerateTooltip(item);
        }
    }

    public void ColorSwap(Color color)
    {
        if (color == Color.clear)
            son.gameObject.SetActive(false);
        else if (color == Color.red)
        {
            transform.position -= new Vector3(1f, 0, 1f);
            meshRenderer.material.color = color;
        }
        else
            meshRenderer.material.color = color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        timeTouch = Time.time;
        Debug.Log("down: " + timeTouch);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Time.time - timeTouch >= 1 && !follow.enabled)
        {
            MyGrid.DotsBlock(transform.position, item.width, item.height, 0);
            Debug.Log("time to create!");
            son.gameObject.SetActive(true);
            this.GetComponent<FollowMousePosition>().enabled = true;
            CubePlacer.pasteObj = this.gameObject;
        }
        Debug.Log("up: " + Time.time);
    }
}