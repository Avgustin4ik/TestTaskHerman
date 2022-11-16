using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Logic
{
    public class SpellView : Spell, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private bool _isCasting;
        private bool _isCooldown;

        [Tooltip("Дефолтное изоброжение, при запуске игры подгрузится новая иконка из scriptable object")]
        [SerializeField]
        private Image _spellImage;

        public bool IsClicked { get; set; }
        public event Action<SpellView> SpellTriggered;

        [Header("Visual ui staff")] [SerializeField]
        private Image _selectionImage;

        [SerializeField] private Image _clickedImage;
        [SerializeField] private Image _cooldownImage;

        private void Awake()
        {
            _spellImage.sprite = GetIcon();
            _selectionImage.enabled = false;
            _clickedImage.enabled = false;
        }

        private IEnumerator CooldownRoutine()
        {
            _cooldownImage.enabled = true;
            _cooldownImage.fillAmount = 1;
            var duration = GetCooldown();
            var timer = duration;
            _isCooldown = true;
            while (true)
            {
                timer -= Time.deltaTime;
                _cooldownImage.fillAmount = timer / duration;
                if (timer < 0) break;
                yield return null;
            }

            _isCooldown = false;
            _cooldownImage.enabled = false;
        }

        public override void Cast(Transform casterTransform) //todo add adirional logic here
        {
            var spellModel = Instantiate(SpellData.SpellPrefab,
                casterTransform.position,
                casterTransform.rotation);
            if (SpellData.IsSpellPassive)
            {
                ((SpellAuraModel)spellModel).Initialization(GetCooldown());
                spellModel.transform.SetParent(casterTransform);
            }

            spellModel.Cast();
            //todo start castTimer
            StartCoroutine(CooldownRoutine());
        }

        #region pointer events

        //todo можно заменить на OnPointerUp
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_isCasting && !_isCooldown)
            {
                if (IsClicked == false) SpellTriggered?.Invoke(this);
                IsClicked = true;
                _clickedImage.enabled = true;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_clickedImage.enabled) return;
            if (_isCooldown) return;
            _selectionImage.enabled = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_clickedImage.enabled) return;
            _selectionImage.enabled = false;
        }

        #endregion

        public void HideFrames()
        {
            IsClicked = false;
            _clickedImage.enabled = false;
            _selectionImage.enabled = false;
        }
    }
}