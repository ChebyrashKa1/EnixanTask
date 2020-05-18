using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private Text tooltipText;
    void Start()
    {
        tooltipText = GetComponent<Text>();
        //gameObject.SetActive(false);
    }

    public void GenerateTooltip(Item item)
    {
        //string statText = "";
        // Debug.Log("tooltiptest: " + item.title + "| " + item.amount + "| " + item.stats.Count);
       /* if (item.stats != null)
        {
            foreach (var stat in item.stats)
            {
                statText += stat.Key.ToString() + ": " + stat.Value.ToString() + "\n";
            }
        }*/
        string tooltip = string.Format("<b>Id:</b> {0} <b>Name:</b> {1} <b>Width:</b> {2} <b>Height:</b> {3}",
                        item.id, item.title, item.width, item.height);
        tooltipText.text = tooltip;
        gameObject.SetActive(true);
    }
}