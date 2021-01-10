using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchType : MonoBehaviour
{
    private float touchTime;
    private bool newTouch=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray,out hitInfo))
            {
                //双击
                //if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                //{
                //    if(Input.GetTouch(0).tapCount==2)
                //    Destroy(hitInfo.collider.gameObject);
                //}

                //长按
                if (Input.touchCount == 1)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        newTouch = true;
                        touchTime = Time.time;
                    }
                    else if (touch.phase == TouchPhase.Stationary)
                    {
                        if(newTouch==true&&Time.time-touchTime>1f)
                        {
                            newTouch = false;
                            Destroy(hitInfo.collider.gameObject);
                        }
                    }
                }
            }
        }
    }
}
