using UnityEngine;

public class TestSkill : ICommand
{
    public bool Execute()
    {
        Debug.Log("Test Skill is active");
        return true;
    }
}
