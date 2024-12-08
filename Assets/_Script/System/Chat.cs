using TMPro;
using UnityEngine;

namespace _Script.System
{
    [RequireComponent(typeof(TMP_Text))]
    public class Chat: MonoBehaviour
    {
        private TMP_Text textField;

        private void Awake()
        {
            textField = GetComponent<TMP_Text>();
        }
    }
}