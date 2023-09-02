using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;
[RequireComponent(typeof(CharacterMovement))]
public class YoungVladlenAnimationChange : MonoBehaviour
{
    [SerializeField] private CharacterMovement _vladlenMovement;

    private void Awake() {
        if(!_vladlenMovement)
        {
            _vladlenMovement = GetComponent<CharacterMovement>();
        }
    }
    private void Update() 
    {
        _vladlenMovement.UpdateAnimator();
    }
}
