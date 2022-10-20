using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;


namespace Enemy {
    public class EnemyBase : MonoBehaviour {
        public float starLife = 10f;
        [SerializeField] private float _currentLife;

        [Header("Animation")]
        [SerializeField] private AnimationBase _animationBase;

        [Header("Start Animation")]
        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithBeginAnimation = true;


        void Awake() {
            Init();
        }

        void Update() {
            if(Input.GetKeyDown(KeyCode.T)) {
                OnDamage(5f);
            }
        }

        protected void ResetLife() {
            _currentLife = starLife;
        }

        protected virtual void Init() {
            ResetLife();
            if(startWithBeginAnimation) {
                BeginAnimation();
            }
        }


        protected virtual void Kill() {
            OnKill();
        }
        protected virtual void OnKill() {
            Destroy(gameObject, 3f);
            PlayAnimationByTrigger(AnimationType.DEATH);
        }

        public void OnDamage(float f) {
            _currentLife -= f;

            if(_currentLife <= 0) {
                Kill();
            }
        }
        #region ANIMATION
        private void BeginAnimation() {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }
        public void PlayAnimationByTrigger(AnimationType animationType) {
            _animationBase.PlayAnimationByTrigger(animationType);
        }

        #endregion

    
    }
}