using UnityEditor;
using UnityEngine;
using System.Collections;

// Creates an instance of a primitive depending on the option selected by the user.
public class EnumTest : MonoBehaviour
{
    


    
}


public class EnumTestEditor : EditorWindow
{
    public enum OPTIONS
    {
        CUBE = 0,
        SPHERE = 1,
        PLANE = 2
    }
    public OPTIONS op;
    [MenuItem("Examples/Editor GUILayout Enum Popup usage")]
    static void Init()
    {
        UnityEditor.EditorWindow window = GetWindow(typeof(EnumTestEditor));
        window.Show();
    }

    void OnGUI()
    {
        op = (OPTIONS)EditorGUILayout.EnumPopup("Primitive to create:", op);
        if (GUILayout.Button("Create"))
            InstantiatePrimitive(op);
    }

    void InstantiatePrimitive(OPTIONS op)
    {
        switch (op)
        {
            case OPTIONS.CUBE:
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = Vector3.zero;
                break;
            case OPTIONS.SPHERE:
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = Vector3.zero;
                break;
            case OPTIONS.PLANE:
                GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                plane.transform.position = Vector3.zero;
                break;
            default:
                Debug.LogError("Unrecognized Option");
                break;
        }
    }
}
