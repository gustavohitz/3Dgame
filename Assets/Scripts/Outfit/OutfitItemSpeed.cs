using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outfit {

    public class OutfitItemSpeed : OutfitItemBase {
        public float targetSpeed = 2f;
        public override void Collect() {
            base.Collect();
            Player.Instance.ChangeSpeed(targetSpeed, duration);
        }
    }
}
