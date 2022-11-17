using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outfit {

    public class OutfitItemStrong : OutfitItemBase {
        public float damageMultiply = .5f;
        public override void Collect() {
            base.Collect();
            Player.Instance.healthBase.ChangeDamageMultiply(damageMultiply, duration);
        }
    }
}
