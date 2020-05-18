using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<GameObject> itemPrefabs = new List<GameObject>();
    void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    void BuildDatabase()
    {
        items = new List<Item>() {
            new Item(0, "house2x1", 2, 1),
            new Item(1, "house3x3", 3, 3),
            new Item(2, "house2x2", 2, 2),
            new Item(3, "tree1", 1, 1),
            new Item(4, "tree2", 2, 2),
            new Item(5, "rock1", 1, 1),
            new Item(6, "rock2", 1, 1),
            new Item(7, "rock3", 1, 1),
            new Item(8, "rock4", 1, 1),
            new Item(9, "branch", 1, 1),
            new Item(10, "stump", 1, 1),
            new Item(11, "tree3", 2, 2)
        };
    }
}