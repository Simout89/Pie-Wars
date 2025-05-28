using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SkillPanel : MonoBehaviour
{
    [Inject] private HistorySelectedData _historySelectedData;
    [SerializeField] private Transform panel;
    [SerializeField] private UISkillButton prefabButton;
    private List<SkillBase> SkillButtons;
    private List<UISkillButton> buttons = new List<UISkillButton>();

    private void Awake()
    {
        SkillButtons = new List<SkillBase>();
    }

    private void OnEnable()
    {
        _historySelectedData.OnSelected += AddSkills;
    }

    private void OnDisable()
    {
        _historySelectedData.OnSelected -= AddSkills;
    }

    public void AddSkills(IEntity entity) // TODO: вызов добавить из истории где то там
    {
        if (buttons.Count > 0)
        {
            foreach (var button in buttons)
            {
                Destroy(button.gameObject); 
            }
            buttons.Clear();
        }
        
        SkillButtons.Clear();
        for (int i = 0; i < entity.skills.Count; i++)
        {
            var button = Instantiate(prefabButton, panel);
            button.Init(entity.skills[i].icon);
            var index= i;
            button.button.onClick.AddListener(() => OnSkillClicked(index));
            buttons.Add(button);
            SkillButtons.Add(entity.skills[i]);
        }
    }

    private void OnSkillClicked(int skillId)
    {
        Debug.Log($"Skill {skillId}");
        SkillButtons[skillId].UseSkill();
    }
}
