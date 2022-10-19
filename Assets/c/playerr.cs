using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerr : MonoBehaviour
{
 CharacterController controller;
    public float speed = 5f;
    public GameObject bullet;
    public GameObject firePoint;
    
    //子彈間隔時間
    public float T = 0.3f;

    //計時
    private float invoke;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
   void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        
        // 旋轉
        if (dir.magnitude > 0.1f)
        {
             float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
             Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
             transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }
        
        // 移動 (x,z)
        Vector3 move = dir * speed;
        
        // 地心引力 (y)
        if (!controller.isGrounded)
        {
             move.y = -9.8f * 30 * Time.deltaTime;
        }
	
        controller.Move( move * speed * Time.deltaTime );

        // 子彈發射
          if (Input.GetKey(KeyCode.Space))
        {
           
           //按鍵後開始計時
           invoke += Time.deltaTime;
           
           //發射
           if (invoke - T > 0)
           {
            Instantiate(bullet, firePoint.transform.position, transform.rotation);
            invoke = 0;
           }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
           invoke = T;
        }
    }

}
