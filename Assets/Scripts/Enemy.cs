using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform targetDestination;
    GameObject targetGameobject;
    Character targetChar;
    [SerializeField] float speed;

    Rigidbody2D rgbd;
    [SerializeField] int hp = 10;
    [SerializeField] int damage = 10;

    private void Awake(){
        rgbd = GetComponent<Rigidbody2D>();
    } 
    public void SetTarget(GameObject target){
        targetGameobject = target;
        targetDestination = target.transform;
    }
    private void FixedUpdate(){
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgbd.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject == targetGameobject){
            Attack();
        }
    }
    private void Attack(){
        if(targetChar == null){
            targetChar = targetGameobject.GetComponent<Character>();
        }
        targetChar.takeDamage(damage);
    }
    public void takeDamage(int damage){
        hp -= damage;
        if(hp <1){
            Destroy(gameObject);
        }
    }

}
 