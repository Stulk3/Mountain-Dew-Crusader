using UnityEngine;
using System;
using System.Collections;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public class ConditionalHideAttribute : PropertyAttribute
{

    public struct Range
    {
        public float min;
        public float max;
        
        public Range(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
    }
    //name of the bool field that will be in controll
    public string ConditionalSourceField = "";
    public string ConditionalSourceField2 = "";

    // False = Hide in inspector, True = disable in inspector
    public bool HideInInspector = false;
    
    public bool Inverse = false;
    public Range range;
    public ConditionalHideAttribute(string conditionalSourceField)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = true;
    }

    public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = hideInInspector;
    }
    
    public ConditionalHideAttribute(string conditionalSourceField,bool hideInInspector,bool inverse,float min = 0, float max =0)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = hideInInspector;
        this.Inverse = inverse;
        this.range = new Range(min,max); 
    }

    public ConditionalHideAttribute(string conditionalSourceField,bool inverse,float min = 0, float max =0)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = true;
        this.Inverse = inverse;
        this.range = new Range(min,max); 
    }



    public ConditionalHideAttribute(string conditionalSourceField,float min = 0, float max =0)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = true;
        this.Inverse = false;
        this.range = new Range(min,max); 
    }
}
