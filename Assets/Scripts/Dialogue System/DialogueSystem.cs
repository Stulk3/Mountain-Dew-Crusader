﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace DialogueSystem{

[RequireComponent(typeof(ActionComponent))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(DialogueVertexAnimator))]
public class DialogueSystem : MonoBehaviour
{
    [Header("Text Settings")]
    [SerializeField] TextMeshProUGUI NameComponent;
    [SerializeField] TextMeshProUGUI TextComponent;
    
    [Space(5f)]
    [Header("Starting Dialogue")]
    [SerializeField] Dialogue startingDialogue;

    [Space(5f)]
    [Header("Sound Settings")]
    [SerializeField] AudioClip SoundEffect;

    [SerializeField] AudioClip CharacterVoice;

    public AudioSource DialogueVoiceSource;
    public ActionComponent ActionComponent;
    
    [Space(5f)]
    [Header("Components")]
    [SerializeField] private DialogueVertexAnimator DialogueVertexAnimator;
    public AudioSourceGroup AudioSourceGroup;
        

    private bool DialogueIsOver = false;
    
    private bool InActionRadius;
    private bool DialogueWindowIsActive;

    private Dialogue Dialogue;
    private bool DialogueIsPlayed = false;


    ////////////////////////
    void Awake()
        {
            DialogueVertexAnimator = new DialogueVertexAnimator(TextComponent, AudioSourceGroup);
        }

    void Start()
    {
        Dialogue = startingDialogue;
        DialogueVoiceSource = this.GetComponent<AudioSource>();
        if (ActionComponent == null)
        {
            ActionComponent = this.GetComponent<ActionComponent>();
        }
        if (DialogueVertexAnimator == null)
        {
            DialogueVertexAnimator = this.GetComponent<DialogueVertexAnimator>();
        }
        
    }
    void Update()
    {
        DetermineBoolVariables();
        ManageDialogue();

    }
    private void ManageDialogue()
    {
        
        ManageDialogueChange();
        
        ManageCharacterVoice();

        ManageDialogueWindowContent();
    }
        private Coroutine typeRoutine = null;
        void PlayDialogue(string message)
        {
            DialogueIsPlayed = true;
            this.EnsureCoroutineStopped(ref typeRoutine);
            DialogueVertexAnimator.textAnimating = false;
            List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
            typeRoutine = StartCoroutine(DialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, CharacterVoice, null));
            
        }

        string SetDialogueName(string name)
        {
            List<DialogueCommand> commands = DialogueUtility.ProcessInputString(name, out string FinalName);
            return FinalName;
        }

        private void ManageDialogueChange()
    {
        var nextDialogue = Dialogue.GetNextDialogue();
        if (InputForDialogueChangeIsPressed(nextDialogue.Length, nextDialogue))
            {
                Dialogue = nextDialogue[0];
                StopVoiceAudioPlaying();
                DialogueIsPlayed = false;
            }
        if (InputForDialogueCloseIsPressed(nextDialogue.Length, nextDialogue))
            {
                DialogueIsOver = true;
                StopVoiceAudioPlaying();
                ActionComponent.CloseDialogueWindow();
            }
     

    
        }   
    void ManageDialogueWindowContent()
        {
            NameComponent.text = Dialogue.GetDialogueName();
            CharacterVoice = Dialogue.GetCharacterVoice();
            if (DialogueWindowIsActive && !DialogueIsPlayed)
            {
                NameComponent.text = SetDialogueName(Dialogue.GetDialogueName());
                PlayDialogue(Dialogue.GetDialogueText());

            }
        }
    void ManageCharacterVoice()
        {
            if (Input.GetKeyDown(KeyCode.E) && CharacterVoice != null && !DialogueIsOver && InActionRadius)
            {

                DialogueVoiceSource.clip = CharacterVoice;
                DialogueVoiceSource.Play();
            }

            else if (Input.GetKeyDown(KeyCode.Mouse0) && CharacterVoice != null && !DialogueIsOver && InActionRadius)
            {

                DialogueVoiceSource.clip = CharacterVoice;
                DialogueVoiceSource.Play();
            }
            else if (Input.GetKeyDown(KeyCode.Space) && CharacterVoice != null && !DialogueIsOver && InActionRadius)
            {

                DialogueVoiceSource.clip = CharacterVoice;
                DialogueVoiceSource.Play();
            }

        }
    bool InputForDialogueChangeIsPressed(int DialogueListLength, Dialogue[] nextDialogue)
    {
        if (Input.GetKeyDown(KeyCode.E) && DialogueWindowIsActive && DialogueListLength > 0 && !DialogueVertexAnimator.textAnimating)
        {
                return true;
            }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && DialogueWindowIsActive && DialogueListLength > 0 && !DialogueVertexAnimator.textAnimating)
        {
                return true;
            }

        else if (Input.GetKeyDown(KeyCode.Space) && DialogueWindowIsActive && DialogueListLength > 0 && !DialogueVertexAnimator.textAnimating)
        {
                return true;
            }
        else
            {
                return false;
            }
    }

     bool InputForDialogueCloseIsPressed(int DialogueListLength, Dialogue[] nextDialogue)
     {
                if (DialogueListLength <= 0 && DialogueWindowIsActive && (Input.GetKeyDown(KeyCode.E)))
                {
                    return true;
                }
                else if (DialogueListLength <= 0 && DialogueWindowIsActive && (Input.GetKeyDown(KeyCode.Mouse0)))
                {
                    return true;
                }
                else if (DialogueListLength <= 0 && DialogueWindowIsActive && (Input.GetKeyDown(KeyCode.Space)))
                {
                    return true;
                }

                else
                {
                    return false;
                }

     }
    void DetermineBoolVariables()
        {
            DialogueWindowIsActive = ActionComponent.GetDialogueWindowIsActive();
            InActionRadius = ActionComponent.GetInActionRadius();
        }
    void StopVoiceAudioPlaying()
        {
            DialogueVoiceSource.Stop();
        }

    public bool GetDialogueIsOver()
        {
            return DialogueIsOver;
        }
}
}
