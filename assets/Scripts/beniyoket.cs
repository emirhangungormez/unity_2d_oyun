using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beniyoket : MonoBehaviour
{
    public int lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        // belli sbir süre zarfından sonra kodun üzerinde bulunduğu game objesi kendisini yok edecektir.
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
