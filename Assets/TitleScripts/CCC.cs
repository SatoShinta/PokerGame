using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CCC : MonoBehaviour
{
   public CineChange cineChange;

    public void OnClick()
    {
        StartCoroutine(cineChange.CangeScene());
    }
}
