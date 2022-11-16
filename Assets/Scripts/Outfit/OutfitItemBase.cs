using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outfit {

    public class OutfitItemBase : MonoBehaviour {
        public OutfitType outfitType;
        public string compareTag = "Player";
        private void OnTriggerEnter(Collider collision) {
            if(collision.transform.CompareTag(compareTag)) {
                Collect();
            }
        }
        public virtual void Collect() {
            HideObject();
        }
        private void HideObject() {
            gameObject.SetActive(false);
        }
        
    }
}
