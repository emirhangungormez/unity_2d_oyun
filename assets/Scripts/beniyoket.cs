using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beniyoket : MonoBehaviour
{
    public int lifeTime;
    
    void Start()
    {
        Destroy(gameObject, lifeTime);
        // belli sbir süre zarfından sonra kodun üzerinde bulunduğu game objesi kendisini yok edecektir.    
    }
    
    void Update()
    {
        
    }
}
