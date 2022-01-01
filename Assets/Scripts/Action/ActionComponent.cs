using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;



public class ActionComponent : MonoBehaviour
{

    [Header("GameObjects")]
    [SerializeField] private GameObject Button;
    [SerializeField] public GameObject DialogueWindow;
     
    [Header("Trigger Collider Settings")]
    [SerializeField] private float TriggerColliderX = 3.2f;
    [SerializeField] private float TriggerColliderY = 2.5f;


    public DialogueSystem.DialogueSystem DialogueSystem;

    public bool DialogueWindowIsActive = false;
    bool InActionRadius = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && InActionRadius==false && DialogueSystem.DialogueIsOver == false)
        {
            Button.SetActive(true);
            InActionRadius = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && InActionRadius == true && DialogueSystem.DialogueIsOver == false) 
        {
            Button.SetActive(false);
            InActionRadius = false;
        }
    }


    private void SetUpTriggerCollider()
    {
        BoxCollider2D TriggerCollider = this.gameObject.AddComponent<BoxCollider2D>();
        TriggerCollider.isTrigger = true;
        Vector2 TriggerSize = new Vector2(TriggerColliderX, TriggerColliderY);
        TriggerCollider.size = TriggerSize;
    }


    private void Awake()
    {
        SetUpTriggerCollider();
        SetDialogueSystemComponent();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InActionRadius == true && DialogueWindowIsActive==false && DialogueSystem.DialogueIsOver==false )
        {
            DialogueWindow.SetActive(true);
            DialogueWindowIsActive = true;
        }

        ActionButtonAppearenceCondition();
    }
    private void ActionButtonAppearenceCondition ()
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
    private void SetDialogueSystemComponent()
    {
        DialogueSystem = this.gameObject.GetComponent<DialogueSystem.DialogueSystem>();
    }

}
