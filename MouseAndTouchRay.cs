using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    RaycastHit _hit;
    private Ray _ray;
    private Vector2 _touchStartPos, _touchEndPos;
    private Touch _touch;
    public static bool isLeft;
    void Update()
    {
        MouseRayCast();
        TouchRayCast();
    }

    void MouseRayCast()
    {
        if ( Input.GetMouseButtonDown (0)){ 
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if ( Physics.Raycast (_ray,out _hit)) {
                Debug.Log("You clicked the " + _hit.transform.name);
            }
        }
    }

    void TouchRayCast()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                _touchStartPos = _touch.position;
                _ray = Camera.main.ScreenPointToRay(_touchStartPos);
                if (Physics.Raycast(_ray, out _hit))
                {
                    Debug.Log("You touched the " + _hit.transform.name);
                }
            }
        }
    }
}