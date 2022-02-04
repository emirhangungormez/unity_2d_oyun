using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamerakontrolü : MonoBehaviour
{
    public Transform target;
    public float cameraSpeed;
    
    void Start()
    {
        
    }

    void Update()
    {
        // transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        // kakarkterin keskin hareketleri kamerayı sert hareket ettirir.
        transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), cameraSpeed);
        // böylece "slerp" komutuyla kamera daha yumuşak hareket eder.
    
    }
}
