using UnityEngine;

public class Slot1 : MonoBehaviour
{
    public SpriteRenderer spriterenderer;
    public Sprite nowSprite;
    [SerializeField] Sprite[] card;
    Animator animator;

    // [SerializeField] SlotStop SlotStop;


    public void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        nowSprite = GetComponent<Sprite>();
        animator = GetComponent<Animator>();
        //  SlotStop =GameObject.Find("SlotManager").GetComponent<SlotStop>();
    }

    public void Update()
    {

    }

    //�����_����sprite�icard�z��̒��ɂ�����́j�ɕύX����
    public void CangeSprite()
    {
        //�J�[�h�̊G���������_���ɑI�����A���̊G�����X���b�g�̖ڂɂ���
        int slotRandomIndex = Random.Range(0, card.Length);
        spriterenderer.sprite = card[slotRandomIndex];
        nowSprite = spriterenderer.sprite;
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
