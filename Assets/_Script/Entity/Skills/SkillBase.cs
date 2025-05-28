using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class SkillBase: ScriptableObject
{
    [SerializeField] public string skillName;
    [SerializeField] public string description;
    [SerializeField] public Texture2D icon;
    
    public virtual void UseSkill()
    {
        
    }
}
