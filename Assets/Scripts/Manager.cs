using SimpleFileBrowser;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] string saveLoadPath = null;

    //save to this path when switching presets, load from it when saving or editing presets
    string rapidFilePath = "C:/ProgramData/Parawave/Rapid/midi_mapping.txt";

    [SerializeField] Button saveButton = null;
    [SerializeField] Button loadButton = null;

    // Start is called before the first frame update
    void Start()
    {
        //    saveAsInputField.onEndEdit.AddListener(PopulateListOfFolders);
        saveButton.onClick.AddListener(() =>{ FileBrowser.ShowSaveDialog(OnSave, null, false, saveLoadPath); });
        loadButton.onClick.AddListener(() => { FileBrowser.ShowLoadDialog(OnLoad, null, false, saveLoadPath); });
    }

    void OnSave(string _s)
    {
        Debug.Log("save: " + _s);
    }
    void OnLoad(string _s)
    {
        Debug.Log("load: " + _s);

    }
}
