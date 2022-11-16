using System.Collections;
using UnityEngine;

namespace Logic
{
    public abstract class Spell : MonoBehaviour
    {
        [field: SerializeField] public SpellData SpellData  { get; private set; }
        public float GetCooldown() => SpellData.CoolDownDuration;
        public float GetCastDuration() => SpellData.CastDuration;
        
        public Sprite GetIcon() => SpellData.SpellIcon;
        
        // public abstract void Cast();
        // public abstract void Cast(Vector3 casterPosition);
        // public abstract void Cast(Vector3 casterPosition, Quaternion casterRotation);
        public abstract void Cast(Transform casterTransform);
    }
}