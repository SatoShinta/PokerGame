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
        //�}�E�X���g���ăv���C���[�̃J�[�h�𓮂���
        //�w��̎��Ԃ��������猳�̈ʒu�ɖ߂�

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

    //���̈ʒu�ɖ߂����\�b�h
    public void PosReset()
    {
        transform.position = syokiPos;
        posTimer = 0;
    }
}
