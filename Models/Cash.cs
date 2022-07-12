namespace CashMachineApp.Models
{
    public class Cash
    {
        public int Nominal = 100;
        public int Count;
        public int CassetteId;
        public Cash(int nominal, int count, int cassette)
        {
            Nominal = nominal;
            Count = count;
            CassetteId = cassette;
        }

        public static explicit operator int(Cash cash) => cash.Count * cash.Nominal;

        public override string ToString() => Count == 0 ? "0" : $"{Count}x{Nominal}₽";
    }
}
