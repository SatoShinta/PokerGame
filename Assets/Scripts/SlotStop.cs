using UnityEngine;

public class SlotStop : MonoBehaviour
{
    [SerializeField, Header("スロット")] GameObject[] slots;
    public Animator[] slotAnimator;
    public int pushCounter;

    void Start()
    {
        //slotsの中にアルオブジェクトの分の配列を作成
        slotAnimator = new Animator[slots.Length];

        //slotsがある分for文を回す（配列の中にあるオブジェクトのアニメーターを取得）
        for (int i = 0; i < slots.Length; i++)
        {
            slotAnimator[i] = slots[i].GetComponent<Animator>();
        }
        //pushCounterの初期化
        pushCounter = 0;
    }

    void Update()
    {
        //スペースキーが押されたとき、
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //pushCounterを＋１し、
            pushCounter++;

            //回数ごとに各スロットのアニメーションを再生する
            switch (pushCounter)
            {
                case 1:
                    slotAnimator[0].Play("stop1");
                    break;
                case 2:
                    slotAnimator[1].Play("stop2");
                    break;
                case 3:
                    slotAnimator[2].Play("stop3");
                    break;
            }
        }
    }
}