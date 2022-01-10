using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{

    public LayerMask ClickableILayer;
    private Ray Ray;
    [SerializeField] Sprite DefaultCursor;
    [SerializeField] Sprite OnClicktCursor;

    private SpriteRenderer CursorRenderer;

    void Awake()
    {
        Cursor.visible = false;
        CursorRenderer = this.GetComponent<SpriteRenderer>();
        CursorRenderer.sprite = DefaultCursor;
    }

    void Update()
    {
        CursorWorldCoordinatesSet();
        Debug.DrawRay(this.transform.position, Ray.direction, Color.green, 2);
        RayCast();
    }


    void RayCast()
    {
        Ray = Camera.main.ScreenPointToRay(Input.mousePosition) ;
        if (Physics.Raycast(Ray,1000, ClickableILayer))
        {
            CursorRenderer.sprite = OnClicktCursor;
            Debug.Log("Да");
        }
        else
        {
            CursorRenderer.sprite = DefaultCursor;
            Debug.Log("Нет");
        }
    }

    void CursorWorldCoordinatesSet()
    {
        Vector2 CursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = CursorPosition;
     
    }

    
}
