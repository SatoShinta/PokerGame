using UnityEngine;

public class SlotStop : MonoBehaviour
{
    [SerializeField, Header("ÉXÉçÉbÉg")] GameObject[] slots;
    public Animator[] slotAnimator;
    public int pushCounter;

    void Start()
    {
        slotAnimator = new Animator[slots.Length];
        for (int i = 0; i < slots.Length; i++)
        {
            slotAnimator[i] = slots[i].GetComponent<Animator>();
        }
        pushCounter = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pushCounter++;

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