using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot1 : MonoBehaviour
{
    public SpriteRenderer spriterenderer;
    public Sprite nowSprite;
    
   // [SerializeField] Sprite[] card;
    [SerializeField, Header("カードの情報")] private List<CardData> _cards = new List<CardData>();



    public void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        nowSprite = GetComponent<Sprite>();
    }

    public void Update()
    {

    }

    //ランダムなsprite（card配列の中にあるもの）に変更する
    public void CangeSprite()
    {
        //カードの絵柄をランダムに選択し、その絵柄をスロットの目にする
        int slotRandomIndex = Random.Range(0, _cards.Count);
        CardData card = _cards[slotRandomIndex];
        spriterenderer.sprite = card.sprite;
        nowSprite = spriterenderer.sprite;
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
