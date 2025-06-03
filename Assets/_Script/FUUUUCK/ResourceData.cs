using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceData
{
    public int Metal = 100;
    public int Energy = 100; 
    public int Crystal = 50;
    public int Food = 200;

    public int GetResource(ResourceType type)
    {
        return type switch
        {
            ResourceType.EmptyDough => Metal,
            ResourceType.SugarConcentrate => Energy,
            ResourceType.WonderfulBeans => Crystal,
            ResourceType.LivingDew => Food,
            _ => 0
        };
    }

    public void AddResource(ResourceType type, int amount)
    {
        switch(type)
        {
            case ResourceType.EmptyDough: Metal += amount; break;
            case ResourceType.SugarConcentrate: Energy += amount; break;
            case ResourceType.WonderfulBeans: Crystal += amount; break;
            case ResourceType.LivingDew: Food += amount; break;
        }
        Debug.Log($"Добыто {amount} {type}. Всего: {GetResource(type)}");
    }

    public bool SpendResource(ResourceType type, int amount)
    {
        if(GetResource(type) >= amount)
        {
            switch(type)
            {
                case ResourceType.EmptyDough: Metal -= amount; break;
                case ResourceType.SugarConcentrate: Energy -= amount; break;
                case ResourceType.WonderfulBeans: Crystal -= amount; break;
                case ResourceType.LivingDew: Food -= amount; break;
            }
            return true;
        }
        return false;
    }
}