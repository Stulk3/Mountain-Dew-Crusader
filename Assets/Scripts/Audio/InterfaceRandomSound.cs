using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InterfaceRandomSound : MonoBehaviour
{
    [SerializeField] AudioClip[] AudioClips;
    [Space(5f)]
    [SerializeField] AudioSource AudioSource;
    private int RandomInteger;
    [SerializeField]private float RandomMultiplier;
    float RandomFloat;
    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        CalculateRandomMultiplier();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          PlayRandomSound();
        }
    }
    private int GetRandomValue()
    {
        RandomFloat = (UnityEngine.Random.value) * RandomMultiplier;
        RandomInteger = Mathf.FloorToInt(RandomFloat);
        return RandomInteger;
    }
    void PlayRandomSound()
    {
        AudioSource.Play();
        AudioSource.clip = AudioClips[GetRandomValue()];
        AudioSource.Play();
    }
    void CalculateRandomMultiplier()
    {
        RandomMultiplier = (float)AudioClips.Length - 0.1f;
    }
}
