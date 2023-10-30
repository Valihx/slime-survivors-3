using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public float attackCooldown = 1.0f; // Minimum time between attacks

    [SerializeField] GameObject leftSwordObject;
    [SerializeField] GameObject rightSwordObject;

    PlayerMove PlayerMove;
    [SerializeField] Vector2 swordAttackSize = new Vector2(4f,2f);
    [SerializeField] int swordDamage = 1;


    private float lastAttackTime;

    private void Awake(){
        PlayerMove = GetComponentInParent<PlayerMove>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastAttackTime >= attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    void Attack()
    {
        if(PlayerMove.lastHorizontalVector > 0){
            rightSwordObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightSwordObject.transform.position,swordAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else{
            leftSwordObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftSwordObject.transform.position,swordAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }   
    private void ApplyDamage(Collider2D[] colliders){
        for(int i = 0 ;i<colliders.Length;i++){
            Enemy e = colliders[i].GetComponent<Enemy>();
            if(e != null){
            colliders[i].GetComponent<Enemy>().takeDamage(swordDamage);
            }

        }
    }
}