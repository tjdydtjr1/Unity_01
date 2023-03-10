using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 나오자마자 전방으로 움직임
        //
        //this.GetComponent<Rigidbody>().velocity = transform.forward * 20;
        // 1 초후에 오브젝트 삭제
        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // 위치는 항상 Transform
        // 중력 사용 시 높이를 통한 조건으로 삭제
        if(transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
