using SklepInternetowy.Data_Access_Layer;
using SklepInternetowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SklepInternetowy.Infrastructure
{
    public class CartManager
    {
        private SupplementsContext _db;
        private ISessionManager _session;

        public CartManager(ISessionManager session, SupplementsContext db )
        {
            this._session = session;
            this._db = db;
        }

        public List<CartPosition> GetCart()
        {
            List<CartPosition> cart;

            if (_session.Get<List<CartPosition>>(Consts.CartSessionKey) == null)
            {
                cart = new List<CartPosition>();

            }

            else
            {
                cart = _session.Get<List<CartPosition>>(Consts.CartSessionKey) as List<CartPosition>;
            }

            return cart;
        }

        public void AddToCart(int supplementId)
        {
            var cart = GetCart();
            var cartposition = cart.Find(k => k.Supplement.SupplementId == supplementId);

            if (cartposition != null)
            {
                cartposition.Amount++;
            }
            else
            {
                var supplementToAdd = _db.Supplements.SingleOrDefault(k => k.SupplementId == supplementId);

                if (supplementToAdd != null)
                {
                    var newCartPosition = new CartPosition()
                    {
                        Supplement = supplementToAdd,
                        Amount = 1,
                        Value = supplementToAdd.Price


                    };
                    cart.Add(newCartPosition);
                }
            }

            _session.Set(Consts.CartSessionKey, cart);
        }

        public int RemoveFromCart(int supplementId)
        {
            var cart = GetCart();
            var cartPosition = cart.Find(k => k.Supplement.SupplementId == supplementId);

            if (cartPosition != null)
            {
                if (cartPosition.Amount > 1)
                {
                    cartPosition.Amount--;
                    return cartPosition.Amount;
                }
                else
                {
                    cart.Remove(cartPosition);
                }
            }

            return 0;
        }

        public decimal GetCartValue()
        {
            var getCart = GetCart();
            return getCart.Sum(k => (k.Amount*k.Supplement.Price));
        }

        public int GetAmountOfCartPositions()
        {
            var cart = GetCart();
            var amount = cart.Sum(k => k.Amount);
            return amount;
        }

        public Order CreateOrder(Order newOrder, string userId)
        {
            var cart = GetCart();
            newOrder.OrderDate = DateTime.Now;
           // newOrder.userId = userId;

            _db.Orders.Add(newOrder);

            if (newOrder.OrderPositions == null)
            {
                newOrder.OrderPositions = new List<OrderPosition>();
                decimal cartValue = 0;

                foreach (var cartItem in cart)
                {
                    var newOrderPosition = new OrderPosition()
                    {
                        SupplementId = cartItem.Supplement.SupplementId,
                        Amount = cartItem.Amount,
                        PurchasePrice = cartItem.Supplement.Price,
                    }
                    ;
                }
            }

        }
    }

}