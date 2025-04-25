using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanel : MonoBehaviour
{
    [SerializeField] private Transform panel;
    [SerializeField] private UISkillButton prefabButton;
    private List<SkillBase> SkillButtons;

    private void Awake()
    {
        SkillButtons = new List<SkillBase>();
    }

    public void AddSkills(IEntity entity) // TODO: вызов добавить из истории где то там
    {
        SkillButtons.Clear();
        for (int i = 0; i < entity.skills.Count; i++)
        {
            var button = Instantiate(prefabButton, panel);
            button.Init(entity.skills[i].icon);
            button.button.onClick.AddListener(() => OnSkillClicked(i));
            SkillButtons.Add(entity.skills[i]);
        }
    }

    private void OnSkillClicked(int skillId)
    {
        SkillButtons[skillId].UseSkill();
    }
}
