using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int currentHP = 100;
    public int maxHP = 100;
    [SerializeField] StatusBar hpBar;
    
    private void Start() {
        hpBar.SetState(currentHP,maxHP);
    }
    private void Update() {
        if(currentHP <= 0){
            GetComponent<PlayerMove>().enabled = false;

        }
    }

    public void takeDamage(int damage){
        currentHP -= damage;
        if(currentHP <=0){
            Debug.Log("YOU DIED");
        }
        hpBar.SetState(currentHP, maxHP);
    }
    public void Heal(int amount){
        if(currentHP <= 0){
            return;
        }
        currentHP += amount;
        if(currentHP>maxHP){
            currentHP=maxHP;
        }
        hpBar.SetState(currentHP, maxHP);
    }
}
