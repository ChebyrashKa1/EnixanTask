using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickStore : MonoBehaviour
{
    public ItemDatabase itemBase;
    public static Item itemToAdd;
    public GameObject spawn, store;
    void Start()
    {

    }
    public void ClickDown(int id)
    {
        //CubePlacer.place = false;
        itemToAdd = new Item(itemBase.GetItem(id));
        CubePlacer.pasteObj = Instantiate(itemBase.itemPrefabs[id]);//pasteObj);
        CubePlacer.pasteObj.transform.parent = spawn.transform;
        ActiveStore();
    }

    public void ActiveStore()
    {
        store.SetActive(!store.activeSelf);
    }
}