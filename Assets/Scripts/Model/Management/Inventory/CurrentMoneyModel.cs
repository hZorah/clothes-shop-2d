using System;
using UnityEngine;

namespace Model.Management.Inventory
{
    [Serializable]
    public class CurrentMoneyModel 
    {
        [SerializeField] private InventoryExceptionMessages _errorMessages;
        [SerializeField] private float _currentMoney;

        public float CurrentMoney { get => _currentMoney; }

        public void IncreaseMoney(float amount)
        {
            if (amount < 0)
                throw new Exception(_errorMessages.AddNegativeMoney);

            _currentMoney += amount;
        }


        public void DecreaseMoney(float amount)
        {
            if (amount < 0)
                throw new Exception(_errorMessages.RemoveNegativeMoney);
            if (_currentMoney - amount < 0)
                throw new Exception(_errorMessages.NotEnoughMoney);

            _currentMoney -= amount;
        }
    }
}