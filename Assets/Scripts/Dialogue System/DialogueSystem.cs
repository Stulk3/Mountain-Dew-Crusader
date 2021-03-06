using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{

    [SerializeField] Text textComponent;
    [SerializeField] Dialogue startingDialogue;



    Dialogue dialogue;




    int num = 0;


    // Start is called before the first frame update
    void Start()
    {
        dialogue = startingDialogue;

        textComponent.text = dialogue.GetDialogueText();
    }

    // Update is called once per frame
    void Update()
    {
        ManageDialogue();
    }




    private void ManageDialogue()
    {
        var nextDialogue = dialogue.GetNextDialogue();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogue = nextDialogue[num + 1];
            num = num + 1;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            dialogue = nextDialogue[num + 1];
            num = num + 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            dialogue = nextDialogue[num + 1];
            num = num + 1;
        }
        if (num > 0)
        {
            if (Input.GetKeyDown(KeyCode.Q) && (num>0)) 
            {
                dialogue = nextDialogue[num - 1];
                num = num - 1;
            }
        }



    }










}
