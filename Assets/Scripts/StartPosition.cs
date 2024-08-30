using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour
{
    Vector3 syokiPos;
    public float posTimer;
    [SerializeField] MouseDrag mouseDrag;

    // Start is called before the first frame update
    void Start()
    {
        mouseDrag = GetComponent<MouseDrag>();
        syokiPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(posTimer);
        if(mouseDrag.cardUp == true)
        {
            if(mouseDrag.cardMove == true)
            {
                if(mouseDrag.cardDown == true)
                {
                    posTimer += Time.deltaTime;
                    if (posTimer > 0.1f)
                    {
                        PosReset();
                        mouseDrag.cardMove = false;
                        mouseDrag.cardUp = false;
                        mouseDrag.cardDown = false;
                    }
                
                
                }
            }
        }
    }

    public void PosReset()
    {
        transform.position = syokiPos;
        posTimer = 0;
    }
}
