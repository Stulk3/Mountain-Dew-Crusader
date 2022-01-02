using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;
using UnityEditor;


public class ActionComponent : MonoBehaviour
{
    public ActionType Action;
    public enum ActionType
    {
        Dialogue = 0,
        Item = 1
    }

    [Space(height: 5f)]
    [Header("Trigger Collider Settings")]
    [SerializeField] private float TriggerColliderX = 3.2f;
    [SerializeField] private float TriggerColliderY = 2.5f;

    [Space(height: 5f)]
    [Header("GameObjects")]
    [SerializeField] private GameObject Button;
    [SerializeField] public GameObject DialogueWindow;


    public bool Kek;


    public DialogueSystem.DialogueSystem DialogueSystem;

    public bool DialogueWindowIsActive = false;
    bool InActionRadius = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && InActionRadius == false && DialogueSystem.DialogueIsOver == false)
        {

            InActionRadius = true;
            if (Button != null)
            {
                Button.SetActive(true);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && InActionRadius == true && DialogueSystem.DialogueIsOver == false)
        {
            
            InActionRadius = false;
            if (Button != null)
            {
                Button.SetActive(false);
            }
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
        if (DialogueSystem == null)
        {
            SetDialogueSystemComponent();
        }
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InActionRadius == true && DialogueWindowIsActive == false && DialogueSystem.DialogueIsOver == false)
        {
            DialogueWindow.SetActive(true);
            DialogueWindowIsActive = true;
        }

        ActionButtonAppearenceCondition();
    }
    private void ActionButtonAppearenceCondition()
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
//[CustomEditor(typeof(ActionComponent))]
//public class ActionComponentEditor : Editor
//{

//    public override void OnInspectorGUI()
//    {
//        var ActionComponent = target as ActionComponent;
//        ActionComponent.Kek = EditorGUILayout.Toggle("Hide Fields", ActionComponent.Kek);
//        if (ActionComponent.Action == 0)
//        {
//            EditorGUI.indentLevel++;
//            EditorGUILayout.PrefixLabel("Object");
//            ActionComponent. = EditorGUILayout.ObjectField(ActionComponent.DialogueWindow);
//        }
//    }
//}
