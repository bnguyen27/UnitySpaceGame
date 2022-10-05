using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PlayerDash : MonoBehaviour {
 
      private Vector3 _target;
     public Camera Camera;
     public bool FollowMouse;
     public bool ShipAccelerates;
     public float ShipSpeed = 2.0f;
 
     public void OnEnable()
     {

     }
 
     public void Update()
     {
         if (Input.GetMouseButton(0))
         {
             _target = Camera.ScreenToWorldPoint(Input.mousePosition);
             _target.z = 0;
         }
 
         var delta = ShipSpeed*Time.deltaTime;
         if (ShipAccelerates)
         {
             delta *= Vector3.Distance(transform.position, _target);
         }
 
         transform.position = Vector3.MoveTowards(transform.position, _target, delta);
     }
 }