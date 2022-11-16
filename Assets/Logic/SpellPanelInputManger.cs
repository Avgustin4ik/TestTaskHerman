using UnityEngine;

namespace Logic
{
    public class SpellPanelInputManger : MonoBehaviour
    {
        [SerializeField] private SpellPanel _spellPanel;
        [SerializeField] private KeyCode _panelOpenKey;

        private void Update()
        {
            if (Input.GetKeyDown(_panelOpenKey))
            {
                if (_spellPanel.IsPanelHide) _spellPanel.Show();
                else _spellPanel.Hide();
            }
        }
    }
}