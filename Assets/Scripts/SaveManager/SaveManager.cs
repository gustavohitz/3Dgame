using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Ebac.Core.Singleton;

public class SaveManager : Singleton<SaveManager> {
    private SaveSetup _saveSetup;
    
    protected override void Awake() {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 2;
        _saveSetup.playerName = "Rafael";
    }

    #region SAVE
    [NaughtyAttributes.Button]
    private void Save() {
        string setupToJson = JsonUtility.ToJson(_saveSetup, true);
        Debug.Log(setupToJson);
        SaveFile(setupToJson);
    }
    public void SaveItems() {
        _saveSetup.coins = Items.ItemManager.Instance.GetItemByType(Items.ItemType.COIN).soInt.value;
        _saveSetup.lifePacks = Items.ItemManager.Instance.GetItemByType(Items.ItemType.LIFE_PACK).soInt.value;
        Save();
    }
    public void SaveLastLevel(int level) {
        _saveSetup.lastLevel = level;
        SaveItems();
        Save();
    }
    #endregion
    private void SaveFile(string json) {
        string path = Application.streamingAssetsPath + "/save.txt";

        Debug.Log(path);
        File.WriteAllText(path, json);
    }

    [NaughtyAttributes.Button]
    private void SaveLevelOne() {
        SaveLastLevel(1);
    }

    [NaughtyAttributes.Button]
    private void SaveLevelFive() {
        SaveLastLevel(5);
    }
}

[System.Serializable]
public class SaveSetup {
    public int lastLevel;
    public float coins;
    public float lifePacks;
    public string playerName;
}
