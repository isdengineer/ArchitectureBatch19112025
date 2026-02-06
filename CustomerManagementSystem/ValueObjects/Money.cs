namespace CustomerManagementSystem.ValueObjects
{
    public class Money
    {
        private decimal _value;

        public decimal Value
        {
            get { return _value; }
        }

        public string Type { get; set; }
        public Money(decimal _value)
        {
            this._value = _value;
        }
        public override bool Equals(object? obj)
        {
            Money m = obj as Money;

            return (this.Value==m.Value);
        }
        public static bool operator ==(Money m1, Money m2)
        {
            if (m1.Value == m2.Value) return true;
            return false;
        }
        public static bool operator !=(Money m1, Money m2)
        {
            if (m1.Value != m2.Value) return true;
            return false;
        }
    }
    public record RecMoney
    {
        public decimal Value { get; init; }
        public RecMoney()
        {
        }

        public RecMoney(decimal value)
        {
            Value = value;
        }
    }
}
