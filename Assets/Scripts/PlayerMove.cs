using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour{

Rigidbody2D rgbd;
public Vector3 movementVector;
public float lastHorizontalVector;
public float lastVerticalVector;

[SerializeField] float speed = 3f;
Animate animate;

private void Awake(){
    rgbd =  GetComponent<Rigidbody2D>();
    movementVector = new Vector3();
    animate = GetComponent<Animate>();
}
// Update is called once per frame
void Update()
{
    movementVector.x = Input.GetAxisRaw("Horizontal");
    movementVector.y = Input.GetAxisRaw("Vertical");       
    if(movementVector.x != 0){
        lastHorizontalVector = movementVector.x;
    } 
    if(movementVector.y != 0){
        lastVerticalVector = movementVector.y;
    }  
    animate.horizontal = movementVector.x;

    movementVector *= speed;
    rgbd.velocity = movementVector;
}
}
