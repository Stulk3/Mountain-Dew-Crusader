using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName ="Dialogue")]
public class Dialogue : ScriptableObject
{

    [TextArea(10, 14)] [SerializeField] string DialogueText;
    [TextArea(10, 14)] [SerializeField] string CharName;
    [SerializeField] Dialogue[] nextDialogue;

    public string GetDialogueName()
        {
            return CharName;
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
