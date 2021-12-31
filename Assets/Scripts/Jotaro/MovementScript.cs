using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Animations;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float MovementMultiplier = 3;
    Transform JotaroTransform;
    Animator JotaroAnimator;
    SpriteRenderer JotaroSprite;
    float Movement;

    //[SerializeField] Animator FadeAnimator;

    void Start()
    {
        JotaroTransform = this.GetComponent<Transform>();
        JotaroAnimator = this.GetComponent<Animator>();
        JotaroSprite = this.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        //if (Input.GetKeyDown("k")) FadeAnimator.SetTrigger("FadeTrigger");
        Movement = Input.GetAxis("Horizontal");
        if (Movement != 0) 
        {
            Move();
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

    void Move()
    {
        JotaroTransform.Translate(new Vector2(Movement, 0) * MovementMultiplier * Time.deltaTime);
    }

}
