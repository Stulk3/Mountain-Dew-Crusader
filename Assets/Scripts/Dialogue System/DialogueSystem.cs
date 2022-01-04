using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace DialogueSystem{

[RequireComponent(typeof(ActionComponent))]
[RequireComponent(typeof(AudioSource))]
public class DialogueSystem : MonoBehaviour
{
    [Header("Text Settings")]
    [SerializeField] TextMeshProUGUI NameComponent;
    [SerializeField] TextMeshProUGUI TextComponent;
    
    [SerializeField] private float DelayBetweenText;
    [Space(5f)]
    [Header("Starting Dialogue")]
    [SerializeField] Dialogue startingDialogue;

    [Space(5f)]
    [Header("Sound Settings")]
    [SerializeField] AudioClip SoundEffect;

    [SerializeField] AudioClip CharacterVoice;

    public AudioSource DialogueVoiceSource;
    public ActionComponent ActionComponent;
    
        
    private bool DialogueIsOver = false;
    
    private bool InActionRadius;
    private bool DialogueWindowIsActive;

    private Dialogue Dialogue;
    private int index;


    ////////////////////////

    private string[] SplitedText;
    private string CurrentText;
    private string TextToAnimate;
    private string PreviosWord;

    void Start()
    {
        Dialogue = startingDialogue;
        DialogueVoiceSource = this.GetComponent<AudioSource>();

        //DialogueText = Dialogue.GetDialogueText;
        if (ActionComponent == null)
        {
            ActionComponent = this.GetComponent<ActionComponent>();
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
        //TextComponent.text = Dialogue.GetDialogueText();
        NameComponent.text = Dialogue.GetDialogueName();
        CharacterVoice = Dialogue.GetCharacterVoice();
        
        AnimateText(Dialogue.GetDialogueText());

    }

    private void AnimateText(string text)
        {
            if (DialogueWindowIsActive)
            {
                SplitedText = text.Split(' ');
                
                TextToAnimate = text;

                StartAnimation(0);
            }
        }


    private IEnumerable StartAnimation(float StartDelay)
        {
            yield return new WaitForSeconds(StartDelay);

            CurrentText = "";

            PreviosWord = SplitedText[0];
            Debug.Log(PreviosWord);
            TextComponent.text = "<i>" + SplitedText[index] + "</i>";

            while(index < SplitedText.Length)
            {
                yield return new WaitForSeconds(DelayBetweenText);

                CurrentText += PreviosWord + " ";
                TextComponent.text = CurrentText + "<i>" + SplitedText[index] +"</i>";


                PreviosWord = SplitedText[index];

                index++;
            }

            yield return new WaitForSeconds(DelayBetweenText);
            TextComponent.text = TextToAnimate;

        }
    private void ManageDialogueChange()
    {
        var nextDialogue = Dialogue.GetNextDialogue();
        if (Input.GetKeyDown(KeyCode.E) && DialogueWindowIsActive && nextDialogue.Length > 0)
        {
                Dialogue = nextDialogue[0];
                StopVoiceAudioPlaying();
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && DialogueWindowIsActive && nextDialogue.Length > 0)
        {
                Dialogue = nextDialogue[0];
                StopVoiceAudioPlaying();
        }

        else if (Input.GetKeyDown(KeyCode.Space) && DialogueWindowIsActive && nextDialogue.Length > 0)
        {
                Dialogue = nextDialogue[0];
                StopVoiceAudioPlaying();
            }
        //// Закрытие окна когда диалог закончен ////
        if (nextDialogue.Length <= 0 && DialogueWindowIsActive && (Input.GetKeyDown(KeyCode.E)))
        {

            DialogueIsOver = true;
            StopVoiceAudioPlaying();
            ActionComponent.CloseDialogueWindow();
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
