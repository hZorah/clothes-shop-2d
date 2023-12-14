using Management.Model;
using Presenter.Shop;
using UnityEngine;
using Utils;

namespace Management.View.UI.Shop
{
    public class ShopModal : MonoBehaviour
    {
        [SerializeField] private GenericUiAnimation _uiAnimation;
        [SerializeField] private CosmeticItem _cosmeticItem;
        [SerializeField] private ShopPresenter _shopPresenter;


        public void SetUp (CosmeticItem item) {
            _cosmeticItem = item;
        }

        public void Buy () {
            _shopPresenter.Buy(_cosmeticItem);
            Close();
        }

        public void Sell() {
            _shopPresenter.Sell(_cosmeticItem);
            Close();
        }


        public void Close()
        {
            _uiAnimation.Disable();
        }
    }
}