    using Logic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "Spell",menuName = "New Spell...",order = 0)]
    public class SpellData : ScriptableObject
    {
        [field: SerializeField] public float CoolDownDuration { get; private set; }
        [field: SerializeField] public float CastDuration { get; private set; }
        [field: SerializeField] public Sprite SpellIcon { get; private set; }
        [field: SerializeField] public bool IsSpellPassive { get; private set; }
        [field: SerializeField] public SpellModel SpellPrefab { get; private set; }
    }