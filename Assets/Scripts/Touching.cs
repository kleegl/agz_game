using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touching : MonoBehaviour
{
    private float _dist;
    private bool _touching = false;
    private Vector3 _offset;
    private Transform _toTouch;

    private void Update()
    {
        Touched();
        if (Input.touchCount > 0)
        {
            print(Input.touchCount);
        }
    }

    public void Touched()
    {
        if (Input.touchCount > 0)
        {
            print(Input.touchCount);
        }
    }





    public void DoTouch()
    {
        if (Input.touchCount != 1)
        {
            print("DoTouch != 1");
            _touching = false;
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            print("DoTouch Began");
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Cube")
                {
                    _toTouch = hit.transform;
                    _dist = hit.transform.position.z - Camera.main.transform.position.z;
                    Vector3 v3 = new Vector3(pos.x, pos.y, pos.z);
                    v3 = Camera.main.ScreenToWorldPoint(v3);
                    _offset = _toTouch.position - v3;
                    _touching = true;
                }
            }
        }

        if (_touching && touch.phase == TouchPhase.Moved)
        {
            print("DoTouch Moved");
            Vector3 v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _dist);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            _toTouch.position = v3 + _offset;
        }

        if(_touching && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
            _touching = false;
    }
}
