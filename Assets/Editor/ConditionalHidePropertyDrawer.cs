using UnityEditor;
using UnityEngine;
using System;

[CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
public class ConditionalHidePropertyDrawer: PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ConditionalHideAttribute HideAttribute = (ConditionalHideAttribute)attribute;

        //Enable/disable the property
        bool enabled = GetConditionalHideAttributeResult(HideAttribute, property);
        bool WasEnabled = GUI.enabled;
        GUI.enabled = enabled;

        if (!HideAttribute.HideInInspector || enabled)
        {
            if(HideAttribute.range.min == HideAttribute.range.max)
            {
                EditorGUI.PropertyField(position,property,label,true);
            }
            else
            {
                //Draw the property as a Slider or IntSlider based on whether it's a float or integer.
                if (property.propertyType == SerializedPropertyType.Float)
                {
                    EditorGUI.Slider(position,property,HideAttribute.range.min, HideAttribute.range.max, label);
                }
                else if(property.propertyType == SerializedPropertyType.Integer)
                {
                    EditorGUI.Slider(position,property, Convert.ToInt32(HideAttribute.range.max), Convert.ToInt32(HideAttribute.range.min),label);
                }
                else
                {
                    EditorGUI.LabelField(position, label.text, "Use Range with float or int.");
                }
                
            }
        }

        GUI.enabled = WasEnabled;
    }


    public bool GetConditionalHideAttributeResult(ConditionalHideAttribute hideAttribute, SerializedProperty property)
    {
        bool enabled = true;
        //Look for the sourcefield within the object that the property belongs to

        string PropertyPath = property.propertyPath; //returns the property path of the property we want to apply the attribute to
        string ConditionPath = PropertyPath.Replace(property.name, hideAttribute.ConditionalSourceField); //changes the path to the conditionalsource property path
        SerializedProperty sourcePropertyValue = property.serializedObject.FindProperty(ConditionPath);
        

        if(sourcePropertyValue != null)
        {
            enabled = sourcePropertyValue.boolValue;
        }
        else
        {
            Debug.LogWarning("Attempting to use a ConditionalHideAttribute but no matching SourcePropertyValue found in object: " + hideAttribute.ConditionalSourceField);
        }
        return enabled;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ConditionalHideAttribute hideAttribute =(ConditionalHideAttribute)attribute;
        bool enabled  = GetConditionalHideAttributeResult(hideAttribute,property);
        
        if(!hideAttribute.HideInInspector || enabled)
        {
            return EditorGUI.GetPropertyHeight(property,label);
        }
        else
        {
            //The property is not being drawn
            //We want to undo the spacing added before and after the property
            return -EditorGUIUtility.standardVerticalSpacing;
        }

    }
}
