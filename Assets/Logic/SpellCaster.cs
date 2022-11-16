using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class SpellCaster : MonoBehaviour
    {
        [SerializeField] private SpellPanel _spellPanel;
        [SerializeField] private float _castDelay;
        private Transform _transofrm;

        private void Awake()
        {
            _transofrm = transform;
            _spellPanel.SpellsQueue += OnSpellsQueue;
        }

        private void OnSpellsQueue(Queue<SpellView> triggeredSpells)
        {
            StartCoroutine(CastRoutine(triggeredSpells));
        }

        private IEnumerator CastRoutine(Queue<SpellView> spellList)
        {
            var delayTime = new WaitForSeconds(_castDelay);
            while (spellList.Count > 0)
            {
                spellList.Dequeue().Cast(_transofrm);
                yield return delayTime;
            }

            spellList.Clear();
        }

        private void OnDestroy()
        {
            _spellPanel.SpellsQueue -= OnSpellsQueue;
        }
    }
}