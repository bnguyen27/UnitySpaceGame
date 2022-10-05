using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float proSpeed = 2f;

    public Rigidbody2D rb;



    Vector2 movement;

    Vector2 velocity;

    public GameObject mProjectile;
    
    private Vector2 _target;
     public Camera Camera;
     public bool FollowMouse;
     public bool accelerates;
     public float dashSpeed = 2.0f;
     
     public float timer;

     public float waitTime = 1.0f;
     bool cooldown = false;
    void Start() {
        
        gameObject.tag = "Player";
        

    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

         

        if (Input.GetMouseButton(1))
         {
    
             var delta = dashSpeed*Time.deltaTime;
             

             _target = Camera.ScreenToWorldPoint(Input.mousePosition);

              if (accelerates)
         {
             delta *= Vector3.Distance(transform.position, _target);
         }

             transform.position = Vector3.MoveTowards(transform.position, _target, delta);
         }

         if (Input.GetMouseButton(0))
         {if(cooldown == false){
                 GameObject clone = (GameObject)Instantiate (mProjectile, rb.position, Quaternion.identity);
                 Vector2 mousePos = Camera.ScreenToWorldPoint(Input.mousePosition);
                 Vector2 directon = mousePos - rb.position;
                clone.GetComponent<Rigidbody2D>().velocity = directon * proSpeed;
                Invoke("ResetCooldown",0.3f);
                cooldown = true;

                FindObjectOfType<AudioManager>().Play("Shoot");

            }
            

         }
    

         
    }

void ResetCooldown(){
     cooldown = false;
    }


}
