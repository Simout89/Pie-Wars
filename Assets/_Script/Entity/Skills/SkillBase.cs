using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill", order = 1)]
public class SkillBase: ScriptableObject
{
    [SerializeField] public Texture2D icon;
    [SerializeField] public float selfDamage;
    [SerializeField] public float damage;
    [SerializeField] public float treatment;
    [SerializeField] public float durationOfAction;
    [SerializeField] public float range;
    [SerializeField] public bool switchable;
    [SerializeField] public float additionalRange;
    [SerializeField] public float additionalMovementSpeed;
    [SerializeField] public float additionalAttackSpeed;

    private bool swtichState;

    public void UseSkill()
    {
        
    }
}
