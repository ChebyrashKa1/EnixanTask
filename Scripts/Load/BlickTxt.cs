using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlickTxt : MonoBehaviour
{
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.color = Color.Lerp(Color.black, Color.clear, Mathf.PingPong(Time.time, 1));
    }
}