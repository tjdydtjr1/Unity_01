using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    float scrollSpeed = 0.3f;
    float offset;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset += scrollSpeed * Time.deltaTime;

        // Star 이미지의 material -> TextureOffset -> X, Y값
        transform.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, offset);
    }
}
