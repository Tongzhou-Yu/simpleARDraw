using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ArDraw : MonoBehaviour
{
    public Camera m_camera;
    public float distanceFromCamera;
    public GameObject m_brush;

    public void Update()
    {
#if UNITY_EDITOR 
        DrawMouse();
#else
DrawTouch();
#endif
    }

    void DrawMouse()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            Vector3 mousePostion = m_camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera));
            Instantiate(m_brush, mousePostion, Quaternion.identity);
        } 
    }

    void DrawTouch()
    {
        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
        {
            Vector3 touchPostion = m_camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, distanceFromCamera));
            Instantiate(m_brush, touchPostion, Quaternion.identity);
        }
    }
}
