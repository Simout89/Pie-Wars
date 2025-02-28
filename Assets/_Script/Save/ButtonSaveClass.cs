using System.IO;
using Newtonsoft.Json; // Используем Newtonsoft.Json для форматирования
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlSettingsManager : MonoBehaviour
{
    private string SettingsFilePath
    {
        get
        {
            // Путь к папке Application Support
            string folderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "../Application Support/YourGame");
            folderPath = Path.GetFullPath(folderPath); // Преобразование в абсолютный путь
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return Path.Combine(folderPath, "controlSettings.json");
        }
    }

    public InputActionAsset inputActions;

    public void SaveSettings()
    {
        // Получаем JSON с привязками
        var bindings = inputActions.SaveBindingOverridesAsJson();

        // Форматируем JSON для читаемости
        var jsonObject = JsonConvert.DeserializeObject<object>(bindings);
        var formattedJson = JsonConvert.SerializeObject(jsonObject, Formatting.Indented); // Formatting.Indented для читаемого формата

        // Сохраняем в файл
        File.WriteAllText(SettingsFilePath, formattedJson);
        Debug.Log($"Control settings saved to {SettingsFilePath}");
    }

    public void LoadSettings()
    {
        if (File.Exists(SettingsFilePath))
        {
            // Читаем привязки из файла
            var bindings = File.ReadAllText(SettingsFilePath);
            inputActions.LoadBindingOverridesFromJson(bindings);
            Debug.Log("Control settings loaded.");
        }
        else
        {
            Debug.LogWarning("No control settings file found, using defaults.");
        }
    }

    public void ResetSettings()
    {
        // Сбрасываем все пользовательские привязки
        inputActions.RemoveAllBindingOverrides();
        Debug.Log("Control settings reset to defaults.");
    }
}
