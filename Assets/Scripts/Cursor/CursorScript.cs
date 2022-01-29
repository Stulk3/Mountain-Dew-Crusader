using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SpriteRenderer))]
public class CursorScript : MonoBehaviour
{

    public LayerMask ClickableLayer;
    private Ray Ray;
    [SerializeField] Sprite DefaultCursor;
    [SerializeField] Sprite OnClicktCursor;

    private SpriteRenderer CursorRenderer;

    void Awake()
    {
        
        CursorRenderer = this.GetComponent<SpriteRenderer>();
        CursorRenderer.sprite = DefaultCursor;
    }

    void Update()
    {
        Cursor.visible = false;
        CursorWorldCoordinatesSet();
        Debug.DrawRay(this.transform.position, Ray.direction, Color.green);
        RayCast();
    }


    void RayCast()
    {
        Ray = Camera.main.ScreenPointToRay(Input.mousePosition) ;
        if (Physics.Raycast(Ray, ClickableLayer))
        {
            CursorRenderer.sprite = OnClicktCursor;
        }
        else
        {
            CursorRenderer.sprite = DefaultCursor;
        }
    }

    void CursorWorldCoordinatesSet()
    {
        Vector2 CursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = CursorPosition;
     
    }

    
}
