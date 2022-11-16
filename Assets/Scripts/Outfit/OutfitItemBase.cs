using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outfit {

    public class OutfitItemBase : MonoBehaviour {
        public OutfitType outfitType;
        public string compareTag = "Player";
        public float duration = 2f;
        private void OnTriggerEnter(Collider collision) {
            if(collision.transform.CompareTag(compareTag)) {
                Collect();
            }
        }
        public virtual void Collect() {
            var setup = OutfitManager.Instance.GetSetupByType(outfitType);
            Player.Instance.ChangeTexture(setup, duration);
            HideObject();
        }
        private void HideObject() {
            gameObject.SetActive(false);
        }
        
    }
}
