using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;
using UnityEditor;


public class ActionComponent : MonoBehaviour
{
    public ActionType Action;
    public enum ActionType : int
    {
        Dialogue = 1,
        Item = 2,
        OnlyDialogue = 3
    }

    [Space(height: 5f)]
    [Header("Trigger Collider Settings")]
    [SerializeField] private float TriggerColliderX = 3.2f;
    [SerializeField] private float TriggerColliderY = 2.5f;

    [Space(height: 5f)]
    [Header("GameObjects")]
    [SerializeField] private GameObject Button;
    [SerializeField] public GameObject DialogueWindow;

    [Space(height: 5f)]
    [Header("Scripts")]
    public DialogueSystem.DialogueSystem DialogueSystem;

    bool DialogueWindowIsActive = false;
    bool InActionRadius = false;
    bool DialogueIsOver = false;


    ///////////////////////////////////////////////////////////////////////////////////////
    private void Awake()
    {
        SetUpActionComponent();
    }
    void Update()
    {

        DetermineBoolVariables();

        CheckForDialogueBeginning();

        ActionButtonDisappear();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (Action)
        {
            case (ActionType.Dialogue):
                DialogueOnTriggerEnter(collision); break;

            case (ActionType.Item): break;

            case (ActionType.OnlyDialogue): break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (Action)
        {
            case (ActionType.Dialogue):
                DialogueOnTriggerExit(collision); break;

            case (ActionType.Item): break;

            case (ActionType.OnlyDialogue): break;
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////

    private void DialogueOnTriggerEnter(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && InActionRadius == false && DialogueIsOver == false)
        {

            InActionRadius = true;
            if (Button != null)
            {
                Button.SetActive(true);
            }
        }
    }
    private void DialogueOnTriggerExit(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && InActionRadius == true && DialogueIsOver == false)
        {

            InActionRadius = false;
            if (Button != null)
            {
                Button.SetActive(false);
            }
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////
   


    private void SetUpTriggerCollider()
    {
        BoxCollider2D TriggerCollider = this.gameObject.AddComponent<BoxCollider2D>();
        TriggerCollider.isTrigger = true;
        Vector2 TriggerSize = new Vector2(TriggerColliderX, TriggerColliderY);
        TriggerCollider.size = TriggerSize;
    }


   
    void CheckForDialogueBeginning()
    {
        if (Input.GetKeyDown(KeyCode.E) && InActionRadius == true && DialogueWindowIsActive == false && DialogueIsOver == false)
        {
            OpenDialogueWindow();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && InActionRadius == true && DialogueWindowIsActive == false && DialogueIsOver == false)
        {
            OpenDialogueWindow();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && InActionRadius == true && DialogueWindowIsActive == false && DialogueIsOver == false)
        {
            OpenDialogueWindow();
        }
    }

    void SetUpActionComponent()
    {
        /////// Диалог ///////
        if (Action == ActionType.Dialogue)
        {
            SetUpTriggerCollider();
            if (DialogueSystemComponentOnObject())
            {
                SetDialogueSystemComponent();
            }
        }

        /////// Предмет ///////
        else if (Action == ActionType.Item)
        {
            SetUpTriggerCollider();
        }


        /////// Диалог-Новелла ///////
        else if (Action == ActionType.OnlyDialogue)
        {

        }
    }

   
    private void ActionButtonDisappear()
    {
        if (DialogueWindowIsActive)
        {
            Button.SetActive(false);
        }
    }
    public void CloseDialogueWindow()
    {
        DialogueWindow.SetActive(false);
        DialogueWindowIsActive = false;
    }

    public void OpenDialogueWindow()
    {
        DialogueWindow.SetActive(true);
        DialogueWindowIsActive = true;
    }

    private void SetDialogueSystemComponent()
    {
        DialogueSystem = this.gameObject.GetComponent<DialogueSystem.DialogueSystem>();
    }

    private bool DialogueSystemComponentOnObject()
    {
        return this.GetComponent<DialogueSystem.DialogueSystem>() != null;
    }

    private void DetermineBoolVariables()
    {
        if (DialogueSystemComponentOnObject())
        {
            DialogueIsOver = DialogueSystem.GetDialogueIsOver();
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////



    public bool GetInActionRadius()
    {
        return InActionRadius;
    }
    public bool GetDialogueWindowIsActive()
    {
        return DialogueWindowIsActive;
    }



}

    ///////////////////////////////////////////////////////////////////////////////////////
public class ActionComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ActionComponent ActionComponent = (ActionComponent)target;


        if (ActionComponent.Action == ActionComponent.ActionType.Dialogue)
        {

        }


        else if (ActionComponent.Action == ActionComponent.ActionType.Item)
        {

        }
        
        else if (ActionComponent.Action == ActionComponent.ActionType.OnlyDialogue)
        {

        }
    }
    
    
}
