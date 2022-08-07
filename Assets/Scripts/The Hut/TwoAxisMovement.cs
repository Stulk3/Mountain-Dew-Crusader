using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Animator))]
public class TwoAxisMovement : MonoBehaviour
{
    [SerializeField] float Speed = 3;
    Transform  VladlenTransform;
    Animator Animator;
    SpriteRenderer Sprite;
    float HorizontalMovementMultiplier;
    float VerticalMovementMultiplier;


    void Start()
    {
        VladlenTransform = this.GetComponent<Transform>();
        Animator = this.GetComponent<Animator>();
        Sprite = this.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        HorizontalMovementMultiplier = Input.GetAxis("Horizontal");
        VerticalMovementMultiplier = Input.GetAxis("Vertical");
        ManageAnimationChange();
        //CheckForSpriteFlip();
        Debug.Log(VerticalMovementMultiplier);
    }

  
    void ManageAnimationChange()
    {
        if (HorizontalMovementMultiplier != 0) 
        {
            MoveHorizontal();
            //PlayRunAnimation();
        }
        else if (VerticalMovementMultiplier != 0)
        {
            MoveVertical();
        }


    void MoveVertical()
    {
        VladlenTransform.Translate(new Vector2(0, VerticalMovementMultiplier) * Speed * Time.deltaTime);
    }
    void MoveHorizontal()
    {
        VladlenTransform.Translate(new Vector2(HorizontalMovementMultiplier, 0) * Speed * Time.deltaTime);
    }
    }
}
