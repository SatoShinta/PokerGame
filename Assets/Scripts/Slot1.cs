using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot1 : MonoBehaviour
{
    public void CangeColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        Color randomColer = new Color(r, g, b);

        Renderer renderer =GetComponent<Renderer>();

        if(renderer != null)
        {
            renderer.material.color = randomColer;
        }
        else
        {
            Debug.Log("‚Í‚¢‚Á‚Ä‚È‚¢");
        }
    }

   
}
