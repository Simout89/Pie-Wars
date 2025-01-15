using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Script.Manager
{
    public class GameManager: MonoBehaviour, IMediatorListener
    {
        private List<Player> _players = new();
        
        private void OnEnable() 
        {
            StructureBreakMediator.Instance.Register(this);
        }

        private void OnDisable()
        {
            StructureBreakMediator.Instance.Unregister(this);
        }

        public void OnEvent(GameObject gameObject)
        {
            Console.WriteLine(gameObject);
        }

        private void GameWin()
        {
            // что то еще
        }

        private void GameLose()
        {
            // что то еще
        }
    }
}