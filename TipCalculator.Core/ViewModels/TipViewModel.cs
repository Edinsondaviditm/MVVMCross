using MvvmCross.ViewModels;
using System.Threading.Tasks;
using TipCalculator.Core.Interfaces;
using TipCalculator.Core.Models;
using TipCalculator.Core.Services;

namespace TipCalculator.Core.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        private readonly ICalculationService _calculationService;
        private readonly IDialogService _dialogService;
        private MvxObservableCollection<Ejemplos> _ejemplos;
        private Ejemplos _ejemplo;
        private decimal _subTotal;
        private int _generosity;
        private decimal _tip;

        public TipViewModel(ICalculationService calculationService,IDialogService dialogService)
        {
            _calculationService = calculationService;
            _dialogService = dialogService;
            LoadEjemplos();
        }

        public Ejemplos Ejemplo
        {
            get => _ejemplo;
            set => SetProperty(ref _ejemplo, value);
        }

        public MvxObservableCollection<Ejemplos> Ejemplos
        {
            get => _ejemplos;
            set => SetProperty(ref _ejemplos, value);
        }

        public decimal SubTotal
        {
            get => _subTotal;
            set
            {
                _subTotal = value;
                RaisePropertyChanged(() => SubTotal);
                Recalculate();
            }
        }

        public decimal Tip
        {
            get => _tip;
            set => SetProperty(ref _tip, value);
        }

        public int Generosity
        {
            get => _generosity;
            set
            {
                _generosity = value;
                RaisePropertyChanged(() => Generosity);
                Recalculate();
            }
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            SubTotal = 100;
            Generosity = 10;
            Recalculate();
        }

        private void Recalculate()
        {
            _dialogService.Alert("Error", "You don'n have the problem", "Accept");
            Tip = _calculationService.TipAmount(SubTotal, Generosity);
        }

        private void LoadEjemplos()
        {
            Ejemplos = new MvxObservableCollection<Ejemplos>
            {
                new Ejemplos { Id = 1, Name = "Ejemplo 1" },
                new Ejemplos { Id = 2, Name = "Ejemplo 2" },
                new Ejemplos { Id = 3, Name = "Ejemplo 3" },
                new Ejemplos { Id = 4, Name = "Ejemplo 4" },
                new Ejemplos { Id = 4, Name = "Ejemplo 5" }
            };
        }
    }
}
