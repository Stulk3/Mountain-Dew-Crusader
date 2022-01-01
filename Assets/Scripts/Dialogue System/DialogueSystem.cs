using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DialogueSystem{

public class DialogueSystem : MonoBehaviour
{

    [SerializeField] Text textComponent;
    [SerializeField] Text nameComponent;
    [SerializeField] Dialogue startingDialogue;

    public ActionComponent ActionComponent;
    public bool DialogueIsOver = false;
    Dialogue dialogue;
    int num = 0;

    void Start()
    {
        dialogue = startingDialogue;
        nameComponent.text = dialogue.GetDialogueName();
        textComponent.text = dialogue.GetDialogueText();
        
        ActionComponent = this.GetComponent<ActionComponent>();
        
    }
    void Update()
    {
        ManageDialogue();

    }
    private void ManageDialogue()
    {
        var nextDialogue = dialogue.GetNextDialogue();
        if (Input.GetKeyDown(KeyCode.E) && ActionComponent.DialogueWindowIsActive && nextDialogue.Length > 0)
        {

            dialogue = nextDialogue[0];

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && ActionComponent.DialogueWindowIsActive && nextDialogue.Length > 0)
        {
            dialogue = nextDialogue[0];

        }
        if (nextDialogue.Length <= 0 && ActionComponent.DialogueWindowIsActive && (Input.GetKeyDown(KeyCode.E)))
        {
            //Debug.Log("Робит");
            DialogueIsOver = true;
            ActionComponent.CloseDialogueWindow();
        }
        textComponent.text = dialogue.GetDialogueText();
        nameComponent.text = dialogue.GetDialogueName();
    }

}
}
