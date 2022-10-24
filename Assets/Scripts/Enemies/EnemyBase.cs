using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;


namespace Enemy {
    public class EnemyBase : MonoBehaviour, IDamageable {

        private Player _player;

        public float starLife = 10f;
        public bool lookAtPlayer = false;
        public Collider collider;
        public FlashColor flashColor;
        public ParticleSystem particleSystem;
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
        void Start() {
            _player = GameObject.FindObjectOfType<Player>();
        }

        public virtual void Update() {
            if(lookAtPlayer) {
                transform.LookAt(_player.transform.position);
            }
        }
        public void Damage(float damage) {
            OnDamage(damage);
        }
        public void Damage(float damage, Vector3 dir) {
            OnDamage(damage);
            transform.DOMove(transform.position - dir, .1f);
        }
        void OnCollisionEnter(Collision other) {
            Player p = other.transform.GetComponent<Player>();

            if(p != null) {
                p.Damage(1);
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
            if(collider != null) {
                collider.enabled = false;
            }
            Destroy(gameObject, 3f);
            PlayAnimationByTrigger(AnimationType.DEATH);
        }

        public void OnDamage(float f) {
            if(flashColor != null) {
                flashColor.Flash();
            }

            if(particleSystem != null) {
                particleSystem.Emit(15);
            }

            transform.position -= transform.forward;
            
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