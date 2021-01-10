using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnLarge : MonoBehaviour
{
    Vector2 oldPos1;
    Vector2 oldPos2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                Vector2 temPos1 = Input.GetTouch(0).position;
                Vector2 temPos2 = Input.GetTouch(1).position;
                if (isEnLarge(oldPos1, oldPos2, temPos1, temPos2))
                {
                    float oldScale = transform.localScale.x;
                    float newScale = oldScale * 1.025f;

                    transform.localScale = new Vector3(newScale, newScale, newScale);
                }
                else
                {
                    float oldScale = transform.localScale.x;
                    float newScale = oldScale / 1.025f;
                    transform.localScale = new Vector3(newScale, newScale, newScale);
                }

                oldPos1 = temPos1;
                oldPos2 = temPos2;
            }
        }
    }

    bool isEnLarge(Vector2 oP1,Vector2 oP2,Vector2 nP1,Vector2 nP2)
    {
        return (oP1 - oP2).magnitude < (nP1 - nP2).magnitude;
    }
}
