using System;

namespace MD.Game.Inventory.Exceptions
{
    public class InventoryInsufficientAmountException : Exception
    {
        public int Available { get; }
        public int Required { get; }

        public InventoryInsufficientAmountException() { }

        public InventoryInsufficientAmountException(string message)
            : base(message) { }

        public InventoryInsufficientAmountException(string message, Exception inner)
            : base(message, inner) { }

        public InventoryInsufficientAmountException(string message, int available, int required)
            : this(message)
        {
            Available = available;
            Required= required;
        }
    }
}
