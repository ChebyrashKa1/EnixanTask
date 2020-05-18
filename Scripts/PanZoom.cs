using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanZoom : MonoBehaviour
{
    float zoomOutMin = 20; //3
    float zoomOutMax = 40;//7
    Vector3 camPos;
    public float speed = 0.01f;
    public float marginX1, marginX2, marginY1, marginY2;
    public GameObject scroll;

    void Update()
    {

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved && CubePlacer.pasteObj == null && !scroll.activeSelf) // движение тач
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed, 0, -touchDeltaPosition.y * speed);
            camPos = transform.position;
            camPos.x = Mathf.Clamp(camPos.x, marginX1, marginX2); // camPos.x = Mathf.Clamp(camPos.x, 6.5f, 13.5f);
            camPos.z = Mathf.Clamp(camPos.z, marginY1, marginY2); //camPos.z = Mathf.Clamp(camPos.z, -10.0f, 5.5f);
            transform.position = new Vector3(camPos.x, 10.0f, camPos.z);
        }
        else if (Input.touchCount == 2) //зум тач
        {

            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector3 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector3 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * speed);
        }
    }

    void zoom(float increment)
    {
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - increment, zoomOutMin, zoomOutMax);
    }
}