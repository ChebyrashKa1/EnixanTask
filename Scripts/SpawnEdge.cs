using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEdge : MonoBehaviour
{
    public ItemDatabase itemBase;
    public GameObject spawn;
    int width = 0, height = 0;
    public GameObject[] edgeObjects = new GameObject[12];

    void Start()
    {
        SpawnCircle();
    }

    void Spawn(Vector3 position)
    {
        int randID = Random.Range(3, 15);
        if (randID < 12)
        {
            Transform go = Instantiate(edgeObjects[randID]).transform;//pasteObj);
            Item itemToAdd = new Item(itemBase.GetItem(randID));
            go.GetComponent<InfoItem>().item = itemToAdd;
            //go.GetComponent<InfoItem>().enabled = false;
            //go.GetComponent<FollowMousePosition>().enabled = false;
            go.parent = spawn.transform;
            //go.GetChild(0).gameObject.SetActive(false);
            width = itemToAdd.width;
            height = itemToAdd.height;
            go.position = position;
            //Debug.Log("pos: " + position);
        }
    }

    void SpawnCircle()
    {
        for (int i = -8; i < 22; i += width) 
        {
            for (int y = 20; y < 30; y += height)
            {
                Spawn(new Vector3(i, 0, y));
            }
        }

        for (int i = 20; i < 30; i += width)
        {
            for (int y = -8; y < 30; y += height)
            {
                Spawn(new Vector3(i, 0, y));
            }
        }
    }
}