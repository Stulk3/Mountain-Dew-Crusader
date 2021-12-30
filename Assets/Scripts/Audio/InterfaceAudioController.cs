using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceAudioController : MonoBehaviour
{
    [SerializeField] int Random;
    [SerializeField] AudioClip[] AudioClips;
    [SerializeField] AudioSource Source;
    float RandomFloat;
    private void Awake()
    {
        Source = GetComponent<AudioSource>();
    }
    void Update()
    {
        RandomFloat = (UnityEngine.Random.value) * 3.9f;
        Random = Mathf.FloorToInt(RandomFloat);
        if (Input.GetMouseButtonDown(0))
        {
            Source.Play();
            Source.clip = AudioClips[Random];
            Source.Play();
        }
    }
}
