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
    [SerializeField] private GameObject DialogueWindow;


    Dialogue dialogue;
    int num = 0;

    void Start()
    {
        dialogue = startingDialogue;
        nameComponent.text = dialogue.GetDialogueName();
        textComponent.text = dialogue.GetDialogueText();
    }
    void Update()
    {
        ManageDialogue();

    }
    private void ManageDialogue()
    {
        var nextDialogue = dialogue.GetNextDialogue();
        if (Input.GetKeyDown(KeyCode.E) && DialogueWindow.activeSelf && nextDialogue.Length > 0)
        {

            dialogue = nextDialogue[0];

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && DialogueWindow.activeSelf && nextDialogue.Length > 0)
        {
            dialogue = nextDialogue[0];

        }
        if (Input.GetKeyDown(KeyCode.Alpha0) && DialogueWindow.activeSelf && nextDialogue.Length > 0)
        {
            dialogue = nextDialogue[0];

        }
        if (nextDialogue.Length == 0 && DialogueWindow.activeSelf && (Input.GetKeyDown(KeyCode.E)))
        {

            DialogueWindow.SetActive(false);
        }
        textComponent.text = dialogue.GetDialogueText();
        nameComponent.text = dialogue.GetDialogueName();
    }

}
}
