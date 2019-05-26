namespace Domain.ValueTypes
{
    public class Age
    {
        public Age(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }
    }
}