using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class cankontrolü : MonoBehaviour
{
    public float health, bulletSpeed;
    bool dead = false;

    Transform muzzle;
    public Transform bullet, floatingText, bloodParticle;
    public Slider slider;
    bool mouseIsNotOverUI;
    
    
    void Start()
    {
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
    }

    
    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null; // UI birimlerine tıklamadığımızda if'in içine gir.
        // böylece pause ekranına basarken atış yapmasını engelliyoruz.
        Time.timeScale = 1;
        if(Input.GetMouseButtonDown(0) && mouseIsNotOverUI) // 0, mouse'un sol tuşu demektir.
        {
            ShootBullet();
        } 
    }

    public void GetDamage(float damage) // zarar verme kodları
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();


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
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3f); // kan oluştur, 3 saniye sonra yok et.
            dataManager.Instance.LoseProcess();
            dead=true;
            Destroy(gameObject); // cesedi yok et.
        }
    }

    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity); // kurşun oluşturma metodu
        // oluşturulacak nesne, oluşturulacağı yer, oluşturulacağı rotasyon)
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
        dataManager.Instance.ShotBullet++;
    }
}
