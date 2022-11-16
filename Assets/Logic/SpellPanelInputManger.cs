using System;
using UnityEngine;

namespace Logic
{
    public class SpellPanelInputManger : MonoBehaviour
    {
        [SerializeField] private SpellPanel _spellPanel;
        [SerializeField] private TMPro.TMP_Text _tipLabel;
        [SerializeField] private KeyCode _panelOpenKey;
        private string _key;

        private void Awake()
        {
            _key = _panelOpenKey.ToString();
        }

        private void Update()
        {
            HandleTipTextLabel();
            if (Input.GetKeyDown(_panelOpenKey))
            {
                if (_spellPanel.IsPanelHide) _spellPanel.Show();
                else _spellPanel.Hide();
            }
        }

        private void HandleTipTextLabel()
        {
            var word = _spellPanel.IsPanelHide ? "open" : "close";
            _tipLabel.text = $"Press {_key} to {word} spell panel";
        }
    }
}