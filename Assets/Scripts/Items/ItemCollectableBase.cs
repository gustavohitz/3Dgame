using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {
    public class ItemCollectableBase : MonoBehaviour {
        public ItemType itemType;

        public string compareTag = "Player";
        public ItemManager itemManager;
        //public HUDBase hudBase;
        public ParticleSystem particleSystem;

        [Header("Sounds")]
        public AudioSource audioSource;

        void Awake() {
            if(particleSystem != null) {
                particleSystem.transform.SetParent(null);
            }
        }

        void OnTriggerEnter(Collider other) {
            if(other.transform.CompareTag(compareTag)) {
                Collect();
                //hudBase.UIUpdate();
            }
        }
        protected virtual void Collect() {
            Destroy(gameObject);
            OnCollect();
        }

        protected virtual void OnCollect() {
            if(particleSystem != null) {
                particleSystem.Play();
            }

            if(audioSource != null) {
                audioSource.Play();
            }
            
            ItemManager.Instance.AddByType(itemType);
        }
        
    }
}
