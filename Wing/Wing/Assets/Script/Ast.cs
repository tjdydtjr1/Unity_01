using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ast : MonoBehaviour
{
    Transform tr;

    int speed;

    public int hp;

    private void Awake()
    {
        tr = transform; // 참조캐싱 최적화에 사용
    }
    // Start is called before the first frame update
    void Start()
    {
        // x,y,z 에 대한 스케일 변경
        tr.localScale = new Vector3(Random.Range(2, 6), Random.Range(2, 6), Random.Range(2, 6));
        speed = Random.Range(10, 20);
        hp = Random.Range(0, 6);
        tr.localPosition = new Vector3(Random.Range(-28, 29), 0, Random.Range(-30, 71));
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector3.back * speed * Time.deltaTime);
        Destroy(tr.gameObject, 5.0f);
    }


    // 미사일 충돌 함수
    public void Hit()
    {
        if(hp > 0)
        {
            --hp;
            Transform expTr = Instantiate(GameManager.instance.expHit, tr.position, tr.rotation);
            Destroy(expTr.gameObject, 1.0f);    // 히트 파티클 제거
        }
        else 
        {
            Transform expTr = Instantiate(GameManager.instance.expDestroy, tr.position, tr.rotation);
            Destroy(expTr.gameObject, 1.0f);    // 폭파 파티클 제거
            Destroy(this.tr.gameObject);    // 자기 자신 제거

            GameManager.instance.scoreText.text = "SCORE:" + (GameManager.instance.score += 100);
        
        }
        

        
    }
}
