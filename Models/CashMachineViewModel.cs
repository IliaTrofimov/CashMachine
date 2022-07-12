using Microsoft.AspNetCore.Mvc.Rendering;

namespace CashMachineApp.Models
{
    public class CashMachineViewModel
    {
        public CashMachine Machine { get; set; } = new CashMachine();
        public int RequestedCash { get; set; } = 1000;
        public int RemainingCash { get; set; }
        public List<Cash> OutputCash { get; set; } = new List<Cash>();
        public bool IsNew { get; set; } = true;
        public TimeSpan ProcessingTime { get; set; }

        public List<SelectListItem> NominalValues = new();

        public int Count { get; set; }


        public CashMachineViewModel()
        {
            foreach(var n in Cassette.NominalValues)
                NominalValues.Add(new SelectListItem($"{n} руб.", n.ToString()));
        }
    }
}
