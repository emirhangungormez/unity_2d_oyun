using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class düşmankontrolü : MonoBehaviour
{
    public float health;
    public float damage;
    bool colliderBusy = false;
    public Slider slider;

    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !colliderBusy)
        // "enemy" objesine değen objenin tag'ı "player" ise ve collider şuan müsaitse içeriye gir.
        {
            colliderBusy = true;
            other.GetComponent<cankontrolü>().GetDamage(damage);
        }
        else if (other.tag == "Bullet")
        // "enemy" objesine değen objenin tag'ı "bullet" ise içeriye gir.
        {
            GetDamage(other.GetComponent<kurşunkontrolü>().bulletDamage);
            Destroy(other.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            colliderBusy = false;
        }
    }

    public void GetDamage(float damage)
    {

        if((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
    }

    private void AmIDead()
    {
        if(health <= 0)
        {
            dataManager.Instance.EnemyKilled++;
            Destroy(gameObject);
        }
    }
}