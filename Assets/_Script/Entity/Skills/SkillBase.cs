using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill", order = 1)]
public class SkillBase: ScriptableObject
{
    [SerializeField] private Texture2D icon;
    [SerializeField] private float selfDamage;
    [SerializeField] private float damage;
    [SerializeField] private float treatment;
    [SerializeField] private float durationOfAction;
    [SerializeField] private float range;
    [SerializeField] private bool switchable;
    [SerializeField] private float additionalRange;
    [SerializeField] private float additionalMovementSpeed;
    [SerializeField] private float additionalAttackSpeed;

    private bool swtichState;

    public void UseSkill()
    {
        
    }
}
