using System.Linq;

namespace CashMachineApp.Models
{
    public class Cassette
    { 
        private static readonly SortedSet<int> values = new() { 100, 200, 500, 1000, 2000, 5000 };

        private int nominalValue = 100;
        private int banknotes = 1;

        public int NominalValue
        {
            get => nominalValue;
            set
            {
                if (!values.Contains(value))
                    throw new ArgumentException("Недопустимое значение номинала кассеты");
                nominalValue = value;
            }
        }

        public int BanknotesCount
        {
            get => banknotes;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Недопустимое количество банкнот (должно быть больше или равно нулю)");
                banknotes = value;
            }
        }

        public int Id { get; set; }

        public static IEnumerable<int> NominalValues => values;

        public bool IsReady { get; set; } = true;
        public static int MaxNominal => values.Max();
        public static int MinNominal => values.Min();



        public Cassette() {}

        public Cassette(int nominal, int count = 0)
        {
            NominalValue = nominal;
            BanknotesCount = count;
        }

        public override string ToString()
        {
            return $"{NominalValue} руб. x {BanknotesCount} шт.";
        }
    }
}
