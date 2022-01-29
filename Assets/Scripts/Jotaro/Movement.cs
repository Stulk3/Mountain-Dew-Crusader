using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Animations;

public class Movement : MonoBehaviour
{
    [SerializeField] float Speed = 3;
    Transform JotaroTransform;
    Animator JotaroAnimator;
    SpriteRenderer JotaroSprite;
    float HorizontalMovementMultiplier;


    void Start()
    {
        JotaroTransform = this.GetComponent<Transform>();
        JotaroAnimator = this.GetComponent<Animator>();
        JotaroSprite = this.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        HorizontalMovementMultiplier = Input.GetAxis("Horizontal");
        ManageAnimationChange();
        CheckForSpriteFlip();
        Debug.Log(HorizontalMovementMultiplier);
    }

    void CheckForSpriteFlip()
    {
        if (HorizontalMovementMultiplier < 0) 
        { 
            JotaroSprite.flipX = true;
        }
        if (HorizontalMovementMultiplier > 0)
        {
            JotaroSprite.flipX = false;
        } 
    }
    void ManageAnimationChange()
    {
        if (HorizontalMovementMultiplier != 0) 
        {
            Move();
            PlayRunAnimation();
        }
        else
        {
            PlayIdleAnimation();
        }
    }

    void PlayRunAnimation()
    {
        JotaroAnimator.Play("Run");
    }
    
    void PlayIdleAnimation()
    {
        JotaroAnimator.Play("Idle");
    }

    void Move()
    {
        JotaroTransform.Translate(new Vector2(HorizontalMovementMultiplier, 0) * Speed * Time.deltaTime);
    }

}
