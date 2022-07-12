using CashMachineApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CashMachineApp.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", new CashMachineViewModel());
        }

        [HttpGet]
        public CashMachineViewModel Example()
        {
            return new CashMachineViewModel();
        }


        [HttpPost]
        public IActionResult SetCassettes([FromForm] CashMachineViewModel viewModel)
        {
            viewModel.Machine.CassettesCount = viewModel.Count;
            return View("Index", viewModel);
        }

        [HttpPost]
        public IActionResult GetCash([FromForm] CashMachineViewModel viewModel)
        {
            DateTime start = DateTime.Now;

            int minNominal = Cassette.MinNominal;
            int cash = viewModel.RequestedCash;
            viewModel.OutputCash.Clear();

            foreach (var cassette in viewModel.Machine.Cassettes
                .Where(c => c.IsReady)
                .OrderByDescending(c => c.NominalValue)
                )
            {
                if (cash < minNominal) break;

                int count = cash / cassette.NominalValue;
                if (count != 0)
                {
                    count = Math.Min(cassette.BanknotesCount, count);
                    viewModel.OutputCash.Add(new(cassette.NominalValue, count));
                    cash -= count * cassette.NominalValue;
                    cassette.BanknotesCount -= count;
                }
                
            }

            viewModel.RemainingCash = cash;
            viewModel.IsNew = false;
            viewModel.ProcessingTime = DateTime.Now - start;

            return View("Index", viewModel);
        }
    }
}