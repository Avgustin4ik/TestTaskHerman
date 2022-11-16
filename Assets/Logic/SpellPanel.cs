using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Logic
{
    public class SpellPanel : MonoBehaviour
    {
        [SerializeField] private KeyCode _panelOpenKey;
        public bool IsPanelHide { get; private set; }
        private List<SpellView> _spells = new List<SpellView>();
        public event Action<Queue<SpellView>> SpellsQueue;
        private Queue<SpellView> spellMutex = new Queue<SpellView>();
        private float _heigth;
        [SerializeField] private float _duration;

        private void Awake()
        {
            foreach (RectTransform child in transform)
            {
                var spell = child.GetComponent<SpellView>();
                _spells.Add(spell);
                spell.SpellTriggered += OnSpellsTriggered;
            }

            var rect = GetComponent<RectTransform>().rect;
            _heigth = rect.height;
            Hide();
        }

        private void OnSpellsTriggered(SpellView spell)
        {
            spellMutex.Enqueue(spell);
        }


        //todo заменить на анимацию с твинами
        public void Hide()
        {
            if (spellMutex.Count > 0) OnSpellsQueue(spellMutex);
            IsPanelHide = true;
            foreach (var spellView in _spells)
                spellView.HideFrames();
            transform.DOMoveY(-_heigth, _duration).SetEase(Ease.InOutCubic);
        }

        public void Show()
        {
            IsPanelHide = false;
            transform.DOMoveY(0, _duration).SetEase(Ease.InOutCubic);
        }

        protected virtual void OnSpellsQueue(Queue<SpellView> spells)
        {
            SpellsQueue?.Invoke(spells);
        }
    }
}