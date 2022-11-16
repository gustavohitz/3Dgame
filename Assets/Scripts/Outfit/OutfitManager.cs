using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

namespace Outfit {

    public enum OutfitType {
        SPEED,

    }

    public class OutfitManager : Singleton<OutfitManager> {
        public List<OutfitSetup> outfitSetups;
        public OutfitSetup GetSetupByType(OutfitType outfitType) {
            return outfitSetups.Find(i => i.outfitType == outfitType);
        }
    }

    [System.Serializable] //para aparecer no Inspector
    public class OutfitSetup {
        public OutfitType outfitType;
        public Texture2D text;
    }
}