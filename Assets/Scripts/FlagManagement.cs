using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlagManagement : MonoBehaviour
{
    public bool slotStart;
    float slotEnd = 0;

    public void Start()
    {
        slotStart = false;
    }

    public void SlotFlag()
    {
        slotStart = true;
        float timer = 0;
        timer += Time.deltaTime;

    }

    public void SlotFlagFalse()
    {
        slotStart = false;
    }
}
