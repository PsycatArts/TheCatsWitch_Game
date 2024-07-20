using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Collider2D col;

    private float moveH, moveV;
    [SerializeField] public float moveSpeed = 2.0f;

    public Joystick joystick;

    public static PlayerMovement Instance;

    private Animator anim;



    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;


        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //WALKING FUNCTIONALITY
        //make player move with FULL movespeed
        if(joystick.Horizontal >= .2f)
        {
            moveH = moveSpeed;
            //Debug.Log("Debug for walking RIGHT");
        }else if(joystick.Horizontal <= -.2f)
        {
            moveH = -moveSpeed;
        }
        else
        {
            moveH = 0f;
        }
        if (joystick.Vertical >= .2f)
        {
            //Debug.Log("Debug for walking UP");
            moveV = moveSpeed;
        }
        else if (joystick.Vertical <= -.2f)
        {
            moveV = -moveSpeed;
        }
        else
        {
            moveV = 0f;
        }
        //----

        moveH = /*Input.GetAxisRaw("Horizontal")*/ joystick.Horizontal* moveSpeed;
        moveV = /*Input.GetAxisRaw("Vertical")*/ joystick.Vertical * moveSpeed;



        //WALKING ANIMATION


        if (joystick.Horizontal >= .2f && joystick.Vertical >= .2f)     // Right & Up = NE
        {
            anim.Play("Run NE");
           // moveH = moveSpeed;
            Debug.Log("Debug for walking RIGHT");
        }
        else if (joystick.Horizontal >= .2f && joystick.Vertical <= .2f)     // Right & Down = SE
        {
            anim.Play("Run SE");
            // moveH = moveSpeed;
            Debug.Log("Debug for walking RIGHT");
        }
        else if (joystick.Horizontal <= -.2f && joystick.Vertical >= -.2f)      //Left & Up = NW
        {
            anim.Play("Run NW");
            //moveH = -moveSpeed;
        }
        else if (joystick.Horizontal <= -.2f && joystick.Vertical <= -.2f)      //Left & Down = SW
        {
            anim.Play("Run SW");
            //moveH = -moveSpeed;
        }
        //else if ( )
        //{
        //    anim.speed = 0;     //if no movement, stop anim.

        //}

        //Debug.Log(moveSpeed.ToString());
        if (moveH == 0 && moveV == 0)
        {
            anim.speed = 0;
            //Debug.Log("No movement");
        }
        else
        {
            anim.speed = 1;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH, moveV);
    }


}
