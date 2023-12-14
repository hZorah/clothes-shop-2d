using TMPro;
using UnityEngine;

namespace Management.View
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField ] private TextMeshProUGUI _moneyText;
        [SerializeField] private string prefix = "money: ";


        
        public void UpdateMoney (float amount) {
            _moneyText.text = prefix + amount;
        }
    }
}