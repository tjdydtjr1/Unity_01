using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 35)
        {
            Destroy(this.gameObject);
        }
    }

    // 충돌시
    private void OnTriggerEnter(Collider other)
    {
        // 비교해서 같은지 other.CompareTag("AST")
        if(other.tag == "AST")
        {
            Destroy(this.gameObject);

            // Ast스크립트에 퍼블릭으로 생성한 Hit함수접근
            // Ast의 Hit()함수 단독 접근 방법
            // 서로 다른 오브젝트 충돌 검출 방법 1
             other.GetComponent<Ast>().Hit(); 

            // 서로 다른 오브젝트 충돌 검출 방법 2
            // RequireReceiver 옵션으로 없으면 에러를 콘솔로 띄워줌
            // DontRequireReceiver 바로 접근하므로 속도가 빠른 장점 에러 안띄움
            // SendMessage를 쓰면 여러 스크립트에 같은 이름의 함수를 다 실행
            //other.SendMessage("Hit", SendMessageOptions.RequireReceiver);

        }
    }
}
