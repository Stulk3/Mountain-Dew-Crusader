using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float MovementMultiplier = 3;
    Transform JotaroTransform;
    Animator JotaroAnimator;
    SpriteRenderer JotaroSprite;
    float Movement;
    
    void Start()
    {
        JotaroTransform = this.GetComponent<Transform>();
        JotaroAnimator = this.GetComponent<Animator>();
        JotaroSprite = this.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {

        Movement = Input.GetAxis("Horizontal");
        if (Movement != 0) 
        {
            JotaroTransform.Translate( new Vector2(Movement, 0) * MovementMultiplier * Time.deltaTime);
            RunAnimation();
        }
        else
        {
            IdleAnimation();
        }
        if (Movement < 0) 
        { 
            JotaroSprite.flipX = true;
        }
        if (Movement > 0)
        {
            JotaroSprite.flipX = false;
        } 
    }


    void RunAnimation()
    {
        JotaroAnimator.Play("Run");
    }
    
    void IdleAnimation()
    {
        JotaroAnimator.Play("Idle");
    }
}
