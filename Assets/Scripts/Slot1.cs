using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Slot1 : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] card;
    Animator animator;


    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
       
    }

    //�����_����sprite�icard�z��̒��ɂ�����́j�ɕύX����
    public void CangeSprite()
    {
        int randomIndex = Random.Range(0, card.Length);
        spriteRenderer.sprite = card[randomIndex];
    }








  /*  public void CangeColor()
    {
        //�����_���ȐF�̒l�����肷��
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        //Color�ɐ�قǐ�������������������
        Color randomColer = new Color(r, g, b);

        Renderer renderer =GetComponent<Renderer>();

        if(renderer != null)
        {
            //���̃I�u�W�F�N�g�̃J���[�������_���ȐF�ɂ���
            renderer.material.color = randomColer;
        }
        else
        {
            Debug.Log("�͂����ĂȂ�");
        }
    }*/

   
}
