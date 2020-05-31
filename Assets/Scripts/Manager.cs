using SimpleFileBrowser;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    string saveLoadPath = "C:\\OneDrive\\Music Stuff\\Rapid MIDI Learn Presets";

    //save to this path when switching presets, load from it when saving or editing presets
    string rapidFilePath = "C:/ProgramData/Parawave/Rapid/midi_mapping.txt";
    string fileExtension = ".txt";

    [SerializeField] Button saveButton = null;
    [SerializeField] Button loadButton = null;
    [SerializeField] Button setPathButton = null;
    [SerializeField] TMP_InputField pathField = null;

    string pathSaveKey = "saveLoadPath";
    
    void Start()
    {
        if(PlayerPrefs.HasKey(pathSaveKey))
        {
            saveLoadPath = PlayerPrefs.GetString(pathSaveKey);
        }

        pathField.text = saveLoadPath;

        InitializeButtons();

        setPathButton.onClick.AddListener(SetDefaultPath);

    }

    void OnSave(string _s)
    {
        string fileContents = File.ReadAllText(rapidFilePath);

        if(!_s.Contains(fileExtension))
        {
            _s += fileExtension;
        }

        File.WriteAllText(_s, fileContents);
    }
    void OnLoad(string _s)
    {
        string fileContents = File.ReadAllText(_s);
        File.WriteAllText(rapidFilePath, fileContents);
    }

    void SetDefaultPath()
    {
        Debug.Log(pathField.text);
        PlayerPrefs.SetString(pathSaveKey, pathField.text);
        saveLoadPath = pathField.text;
    }

    void InitializeButtons()
    {
        saveButton.onClick.RemoveAllListeners();
        loadButton.onClick.RemoveAllListeners();
        saveButton.onClick.AddListener(() => { FileBrowser.ShowSaveDialog(OnSave, null, false, saveLoadPath); });
        loadButton.onClick.AddListener(() => { FileBrowser.ShowLoadDialog(OnLoad, null, false, saveLoadPath); });
    }
}
