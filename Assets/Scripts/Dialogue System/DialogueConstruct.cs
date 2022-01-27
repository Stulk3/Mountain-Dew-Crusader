using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Windows;

[CreateAssetMenu(menuName ="Dialogue/Dialogue")]

public class DialogueConstruct : ScriptableObject
{
   [SerializeField] string FolderName;
   private int LineIndex;
   
   string assetPath;


    public void ConstuctDialogue()
    {

    }

    public void RefreshData()
    {

    }
    public void CreateDialogueLine()
    {
        CreateFolder();
        
        var DialogueLine = ScriptableObject.CreateInstance<DialogueLine>();
        AssetDatabase.CreateAsset(DialogueLine, assetPath + "/"+ LineIndex +".asset");
        LineIndex++;
        //ProjectWindowUtil позволяет при создании сразу открывать Ассет
    }

    public void CreateFolder()
    {
        assetPath = "Assets/Dialogues/" + FolderName;
        if(!Directory.Exists(assetPath))
        Directory.CreateDirectory(assetPath);
        AssetDatabase.Refresh();
    }

}




[CustomEditor(typeof(DialogueConstruct))]
public class DialogueConstructEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        DialogueConstruct construct = (DialogueConstruct)target;

        if(GUILayout.Button("Create Dialogue Line"))
        {
            construct.CreateDialogueLine();
        }
        
    }
}