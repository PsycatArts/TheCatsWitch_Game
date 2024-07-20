using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Handle : MonoBehaviour//, IPointerClickHandler,
                                  //IPointerDownHandler/*, IPointerEnterHandler,*/
//IPointerUpHandler, IPointerExitHandler
{

    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 10f;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;
        }
    }
    //void Start()
    //{

    //   // addEventSystem();

    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    //if (Input.touchCount > 0)
    //    //{
    //    //    touch = Input.GetTouch(0);
    //    //    if (touch.phase == TouchPhase.Moved)
    //    //    {
    //    //        transform.position = new Vector3(
    //    //            transform.position.x + touch.deltaPosition.x * 2,
    //    //            transform.position.y,
    //    //            transform.position.z + touch.deltaPosition.y * 2);
    //    //    }
    //    //}
    //}


    ////mouse-finger down 
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("Mouse Down!");
    //    this.gameObject.transform.position = eventData.position;


    //}


    ////mouse-finger up
    //public void OnPointerClick(PointerEventData eventData)
    //{

    //    // Debug.Log("Mouse Clicked!");
    //}


  


    //void addEventSystem()
    //{
    //    GameObject eventSystem = null;
    //    GameObject tempObj = GameObject.Find("EventSystem");
    //    if (tempObj == null)
    //    {
    //        eventSystem = new GameObject("EventSystem");
    //        eventSystem.AddComponent<EventSystem>();
    //        eventSystem.AddComponent<StandaloneInputModule>();
    //    }
    //    else
    //    {
    //        if ((tempObj.GetComponent<EventSystem>()) == null)
    //        {
    //            tempObj.AddComponent<EventSystem>();
    //        }

    //        if ((tempObj.GetComponent<StandaloneInputModule>()) == null)
    //        {
    //            tempObj.AddComponent<StandaloneInputModule>();
    //        }
    //    }

    //}
}
