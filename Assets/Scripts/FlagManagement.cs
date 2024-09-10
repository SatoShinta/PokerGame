using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlagManagement : MonoBehaviour
{
    public bool slotStart = false;

    public void Start()
    {
        
    }

    public void SlotFlag()
    {
        slotStart = true;
    }

    public void SlotFlagFalse()
    {
        slotStart = false;
    }
}
