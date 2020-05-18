using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;
    public string title;
    public int width;
    public int height;

    public Item(int id, string title, int width, int height)
    {
        this.id = id;
        this.title = title;
        this.width = width;
        this.height = height;
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.width = item.width;
        this.height = item.height;
    }

    public void Use()
    {
        //  if (consumables)
        //  Debug.Log("it's consumables!");
    }
}