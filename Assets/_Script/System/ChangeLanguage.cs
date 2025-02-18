using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class ChangeLanguage : MonoBehaviour
{
    private bool _active;
    
    public void ChangeLocale(int localeID)
    {
        if(_active)
            return;
        StartCoroutine(SetLocate(localeID));
    }
    
    IEnumerator SetLocate(int localeID)
    {
        _active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        _active = false;
    }
}
