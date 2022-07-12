namespace CashMachineApp.Models
{
    public class Cash
    {
        public int Nominal = 100;
        public int Count;

        public Cash(int nominal, int count)
        {
            Nominal = nominal;
            Count = count;
        }

        public static explicit operator int(Cash cash) => cash.Count * cash.Nominal;

        public override string ToString() => Count == 0 ? "0" : $"{Count}x{Nominal}₽";
    }
}
