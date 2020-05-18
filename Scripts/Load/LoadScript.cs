using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScript : MonoBehaviour
{
    public Slider slider;
    public GameObject panel;
    private AsyncOperation asyncOperation;
    public Text txtLoad;

    public void ClickAsync(int level)
    {
        panel.SetActive(true);
        StartCoroutine(Loading(level));
    }


    IEnumerator Loading(int level)
    {
        asyncOperation = SceneManager.LoadSceneAsync(level);
        while (!asyncOperation.isDone)
        {
            txtLoad.text = "Loading " + (asyncOperation.progress * 100) + "%";
            slider.value = asyncOperation.progress;
            Debug.Log("asOP: " + (asyncOperation.progress * 100));
            yield return null;
        }
    }
}
