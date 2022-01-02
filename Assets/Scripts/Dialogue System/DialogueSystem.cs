using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DialogueSystem{

[RequireComponent(typeof(ActionComponent))]
[RequireComponent(typeof(AudioSource))]
public class DialogueSystem : MonoBehaviour
{

    [SerializeField] Text TextComponent;
    [SerializeField] Text NameComponent;
    [SerializeField] Dialogue startingDialogue;

    [SerializeField] AudioClip SoundEffect;

    [SerializeField] AudioClip CharacterVoice;

    public AudioSource DialogueVoiceSource;
    public ActionComponent ActionComponent;
    public bool DialogueIsOver = false;
    private Dialogue Dialogue;
    int num = 0;

    void Start()
    {
        Dialogue = startingDialogue;
        NameComponent.text = Dialogue.GetDialogueName();
        TextComponent.text = Dialogue.GetDialogueText();
        DialogueVoiceSource = this.GetComponent<AudioSource>();

        if (ActionComponent == null)
        {
            ActionComponent = this.GetComponent<ActionComponent>();
        }
        
        
    }
    void Update()
    {
        ManageDialogue();

    }
    private void ManageDialogue()
    {
        
        DialogueWorkConditions();
        
        TextComponent.text = Dialogue.GetDialogueText();
        NameComponent.text = Dialogue.GetDialogueName();
        CharacterVoice = Dialogue.GetCharacterVoice();
        if (Input.GetKeyDown(KeyCode.E) && CharacterVoice != null && !DialogueIsOver)
        {
                
                DialogueVoiceSource.clip = CharacterVoice;
                DialogueVoiceSource.Play();
            }


    }


    private void DialogueWorkConditions()
    {
        var nextDialogue = Dialogue.GetNextDialogue();
        if (Input.GetKeyDown(KeyCode.E) && ActionComponent.DialogueWindowIsActive && nextDialogue.Length > 0)
        {
                Dialogue = nextDialogue[0];
                StopVoiceAudioPlaying();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && ActionComponent.DialogueWindowIsActive && nextDialogue.Length > 0)
        {
                Dialogue = nextDialogue[0];
                StopVoiceAudioPlaying();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && ActionComponent.DialogueWindowIsActive && nextDialogue.Length > 0)
        {
                Dialogue = nextDialogue[0];
                StopVoiceAudioPlaying();
            }
        //// Закрытие окна когда диалог закончен ////
        if (nextDialogue.Length <= 0 && ActionComponent.DialogueWindowIsActive && (Input.GetKeyDown(KeyCode.E)))
        {

            DialogueIsOver = true;
            StopVoiceAudioPlaying();
            ActionComponent.CloseDialogueWindow();
        }

    }

    void StopVoiceAudioPlaying()
        {
            DialogueVoiceSource.Stop();
        }

}
}
