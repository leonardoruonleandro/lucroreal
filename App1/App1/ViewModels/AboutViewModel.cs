using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
        }

        public ICommand OpenWebCommand { get; }

        private double _precoDeCompra;
        public double PrecoDeCompra { get { return _precoDeCompra; } set { _precoDeCompra = value; CalcularLucroReal(); } }

        private double _creditoICMSPercentual;
        public double CreditoICMSPercentual { get { return _creditoICMSPercentual; } set { _creditoICMSPercentual = value; CalcularLucroReal(); } }

        public double CreditoICMSRS { get ; private set; }

        private double _creditoPISPercentual;
        public double CreditoPISPercentual { get { return _creditoPISPercentual; } set { _creditoPISPercentual = value; CalcularLucroReal(); } }
        public double CreditoPISRS { get; private set; }

        private double _acrescimoIPIPercentual;
        public double AcrescimoIPIPercentual { get { return _acrescimoIPIPercentual; } set { _acrescimoIPIPercentual = value; CalcularLucroReal(); } }
        public double AcrescimoIPIRS { get; private set; }
        public double PrecoDeCusto { get; private set; }

        private double _precoDeVenda;
        public double PrecoDeVenda { get { return _precoDeVenda; } set { _precoDeVenda = value; CalcularLucroReal(); } }

        private double _debitoICMSPercentual;
        public double DebitoICMSPercentual { get { return _debitoICMSPercentual; } set { _debitoICMSPercentual = value; CalcularLucroReal(); } }
        public double DebitoICMSRS { get; private set; }

        private double _debitoPISPercentual;
        public double DebitoPISPercentual { get { return _debitoPISPercentual; } set { _debitoPISPercentual = value; CalcularLucroReal(); } }
        public double DebitoPISRS { get; private set; }
        public double LucroBrutoRS { get; private set; }
        public double LucroBrutoPercentual { get; private set; }

        private void CalcularLucroReal()
        {
            CreditoICMSRS = PrecoDeCompra * CreditoICMSPercentual / 100;
            CreditoPISRS = PrecoDeCompra * CreditoPISPercentual / 100;
            AcrescimoIPIRS = PrecoDeCompra * AcrescimoIPIPercentual / 100;
            PrecoDeCusto = PrecoDeCompra - CreditoICMSRS - CreditoPISRS + AcrescimoIPIRS;
            DebitoICMSRS = PrecoDeVenda * DebitoICMSPercentual / 100;
            DebitoPISRS = PrecoDeVenda * DebitoPISPercentual / 100;
            LucroBrutoRS = PrecoDeVenda - DebitoICMSRS - DebitoPISRS - PrecoDeCusto;
            LucroBrutoPercentual = LucroBrutoRS / PrecoDeVenda * 100;

            OnPropertyChanged(nameof(CreditoICMSRS));
            OnPropertyChanged(nameof(CreditoPISRS));
            OnPropertyChanged(nameof(AcrescimoIPIRS));
            OnPropertyChanged(nameof(PrecoDeCusto));
            OnPropertyChanged(nameof(DebitoICMSRS));
            OnPropertyChanged(nameof(DebitoPISRS));
            OnPropertyChanged(nameof(LucroBrutoRS));
            OnPropertyChanged(nameof(LucroBrutoPercentual));
        }

    }
}