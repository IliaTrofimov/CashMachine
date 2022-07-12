
namespace CashMachineApp.Models
{
    public class CashMachine
    {
        public List<Cassette> Cassettes { get; set; } = new List<Cassette>() { new Cassette() };

        public int CassettesCount
        {
            get => Cassettes.Count;
            set
            {
                if (value <= 0 || value > 8)
                    throw new ArgumentOutOfRangeException(nameof(value), "Количество кассет должно быть в диапазоне от 1 до 8");
                
                if (Cassettes.Count < value)
                    while (Cassettes.Count < value)
                        Cassettes.Add(new Cassette());
                else
                    Cassettes.RemoveRange(value - 1, Cassettes.Count - value);
            }
        }

        public void AddCassette(Cassette cassette)
        {
            if (Cassettes.Count < 8)
                Cassettes.Add(cassette);
            else
                throw new Exception("Нельзя добавить больше 8 кассет");
        }

        public void RemoveCassete(Cassette cassette)
        {
            Cassettes.Remove(cassette);
        }

        public List<Cassette> SortCassettes()
        {
            return Cassettes.Where(c => c.IsReady).OrderByDescending(c => c.NominalValue).ToList();
        }

    }
}
