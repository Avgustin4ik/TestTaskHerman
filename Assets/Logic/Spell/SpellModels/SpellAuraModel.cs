using System;
using UnityEngine;

namespace Logic
{
    public class SpellAuraModel : SpellModel
    {
        [SerializeField] private ParticleSystem _auraVfx;
        private void Awake()
        {
        }
        public void Initialization(float lifeTime)
        {
            Destroy(gameObject,lifeTime);
        }

        public override void Cast()
        {
            _auraVfx.Play();
            //todo increase stats logic
        }

        private void OnDestroy()
        {
            //todo end aura and decrease stats logic
        }
    }
}