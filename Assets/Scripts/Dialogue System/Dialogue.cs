using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName ="Dialogue")]
public class Dialogue : ScriptableObject
{
    [TextArea(1, 1)] [SerializeField] string CharacterName;
    [TextArea(10, 14)] [SerializeField] string DialogueText;
    [SerializeField] Dialogue[] nextDialogue;

    public string GetDialogueName()
        {
            return CharacterName;
        }
    public string GetDialogueText()
    {
        return DialogueText;
    }
    public Dialogue[] GetNextDialogue()
    {
        return nextDialogue;
    }
}
