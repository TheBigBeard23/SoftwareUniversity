using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPatternDemo
{
    public class ProductCommand : ICommand
    {
        private readonly Product product;
        private PriceAction priceAction;
        private readonly int amount;

        public ProductCommand(Product product,PriceAction priceAction,int amount)
        {
            this.product = product;
            this.priceAction = priceAction;
            this.amount = amount;
        }
        public void ExecuteAction()
        {
            if (priceAction == PriceAction.Increase)
            {
                product.IncreasePrice(amount);
            }
            else
            {
                product.DecreasePrice(amount);
            }
        }

        public void UndoAction()
        {
            if (this.priceAction == PriceAction.Increase)
            {
                this.priceAction = PriceAction.Decrease;
            }
            else
            {
                this.priceAction = PriceAction.Increase;
            }
        }
    }
}
