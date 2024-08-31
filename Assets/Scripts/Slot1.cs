using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Slot1 : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] card;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void CangeSprite()
    {
        int randomIndex = Random.Range(0,53);

        spriteRenderer.sprite = card[randomIndex];
    }








  /*  public void CangeColor()
    {
        //ランダムな色の値を決定する
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        //Colorに先ほど生成した数字を代入する
        Color randomColer = new Color(r, g, b);

        Renderer renderer =GetComponent<Renderer>();

        if(renderer != null)
        {
            //このオブジェクトのカラーをランダムな色にする
            renderer.material.color = randomColer;
        }
        else
        {
            Debug.Log("はいってない");
        }
    }*/

   
}
