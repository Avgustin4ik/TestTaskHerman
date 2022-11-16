using UnityEngine;

namespace Logic
{
    public class SpellBallModel : SpellModel
    {
        private bool _spellIsCasted;
        [SerializeField] private float _lifeTime = 10f;
        [SerializeField] private float _movementSpeed = 10f;

        private void Awake()
        {
            Cast();
            Destroy(gameObject,_lifeTime);
        }

        public override void Cast()
        {
            //vfx cast logic
            _spellIsCasted = true;

        }

        private void FixedUpdate()
        {
            if(_spellIsCasted == false) return;
            transform.position += transform.forward * (_movementSpeed * Time.fixedDeltaTime);
        }

        private void OnDestroy()
        {
            //todo vfx destroy logic
        }
    }
}