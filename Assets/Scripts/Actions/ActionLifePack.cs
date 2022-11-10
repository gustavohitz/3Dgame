using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class ActionLifePack : MonoBehaviour {
    public KeyCode keyCode = KeyCode.L;
    public SOInt soInt;

    void Start() {
        soInt = ItemManager.Instance.GetItemByType(ItemType.LIFE_PACK).soInt;
    }
    void RecoverLife() {
        if(soInt.value > 0) {
            ItemManager.Instance.RemoveByType(ItemType.LIFE_PACK);
            Player.Instance.healthBase.ResetLife();
        }
    }
    void Update() {
        if(Input.GetKeyDown(keyCode)) {
            RecoverLife();
        }
    }
}
