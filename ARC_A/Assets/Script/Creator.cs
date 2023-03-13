using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    // 생성 오브젝트
    public GameObject prefab;
    public Vector3 rndPosRange;

    public float minGenTime = 0f;
    public float maxGenTime = 2f;

    // 소거 시간
    public float leftTime = 5f;

    // 위치와 속도
    public Vector2 rBodyVelocity;
    public float minSpeed = 1f;
    public float maxSpeed = 4f;

    // 코루틴 제어 플래그
    bool isGen = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.state != GameManager.STATE.PLAY)
        {
            return;
        }

        StartCoroutine(Creators());
    }


    IEnumerator Creators()
    {
        
        if (!isGen)
        {
            isGen = true;
            Vector3 rndPos = Vector3.zero;
            rndPos.x = Random.Range(-rndPosRange.x, rndPosRange.x);
            rndPos.y = Random.Range(-rndPosRange.y, rndPosRange.y);

            Vector3 pos = transform.position + rndPos;
            GameObject obj = Instantiate(prefab, pos, transform.rotation);

            
            // 오류뜸
            //obj.GetComponent<>().velocity = rBodyVelocity * Random.Range(minSpeed, maxSpeed);
            
            Destroy(obj, leftTime);

          
            
            yield return new WaitForSeconds(Random.Range(minGenTime, maxGenTime));
            isGen = false;

        }
    }

}
