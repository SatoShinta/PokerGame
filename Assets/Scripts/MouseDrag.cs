using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 offset;
    public bool cardUp;
    public bool cardMove;
    public bool cardDown;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        cardUp = true;
        offset = transform.position - mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        cardMove = true;
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition) + offset;
        transform.position = newPosition;
    }

    private void OnMouseUp()
    {
        if(cardMove == true)
        {
            cardDown = true;
        }
        
    }
}