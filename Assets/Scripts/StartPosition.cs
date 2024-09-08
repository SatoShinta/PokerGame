using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour
{
    Vector3 syokiPos;
    public float posTimer;
    [SerializeField] MouseDrag mouseDrag;

    void Start()
    {
        mouseDrag = GetComponent<MouseDrag>();
        syokiPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //マウスを使ってプレイヤーのカードを動かし
        //指定の時間がたったら元の位置に戻す

        if(mouseDrag.cardUp == true)
        {
            if(mouseDrag.cardMove == true)
            {
                if(mouseDrag.cardDown == true)
                {
                    posTimer += Time.deltaTime;
                    if (posTimer > 0.1f)
                    {
                        PosReset();
                        mouseDrag.cardMove = false;
                        mouseDrag.cardUp = false;
                        mouseDrag.cardDown = false;
                    }
                
                
                }
            }
        }
    }

    //元の位置に戻すメソッド
    public void PosReset()
    {
        transform.position = syokiPos;
        posTimer = 0;
    }
}
