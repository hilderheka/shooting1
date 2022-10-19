using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bl : MonoBehaviour
{
    Rigidbody rb;
    float lifeTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 50;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > 10)
        {
            Destroy(gameObject);
        }
        /*以下沒成功
        this.transform.Translate(GameObject.FindWithTag("bullet").transform.localPosition*10*Time.deltaTime,Space.Self);
        */
    }
    
}