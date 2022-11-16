using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outfit;


namespace Outfit {
    public class OutfitChanger : MonoBehaviour {
        public SkinnedMeshRenderer mesh;
        public Texture2D texture;
        public string shaderIdName = "_EmissionMap";

        private Texture2D _defaultTexture;

        void Awake() {
            _defaultTexture = (Texture2D) mesh.sharedMaterials[0].GetTexture(shaderIdName);
        }

        [NaughtyAttributes.Button]
        private void ChangeTexture() {
            mesh.sharedMaterials[0].SetTexture(shaderIdName, texture);
        }
        public void ChangeTexture(OutfitSetup setup) {
            mesh.sharedMaterials[0].SetTexture(shaderIdName, setup.text);
        }
        public void ResetTexture() {
            mesh.sharedMaterials[0].SetTexture(shaderIdName, _defaultTexture);
        }

    }
}
