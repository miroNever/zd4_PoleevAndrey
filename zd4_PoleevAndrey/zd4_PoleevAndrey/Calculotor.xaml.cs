using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd4_PoleevAndrey
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 :ContentPage
    {
        public Page1 ()
        {
            InitializeComponent();
        }
        private void SliderValueChange (object sender, ValueChangedEventArgs e)
        {
            SliderLabel.Text = $"{Slider.Value}%";
            if (LoanEntry.Text != String.Empty && Term.Text != String.Empty)
            {
                Calculator(LoanEntry.Text, Term.Text, PaymentTypePicker.SelectedIndex, Slider.Value);
            } else
            {
                MonthlyPaymentLabel.Text = "Ежемесячный платеж: ...";
                TotalLabel.Text = "Общая сумма: ...";
                OverpaymentLabel.Text = "Переплата: ...";
            }

        }

        private void Calculator (string loanAmount, string loanTermInMonths, int PickerPayment, double interestRate)
        {
            try
            {
                if (Convert.ToDouble(LoanEntry.Text) > 0 && Convert.ToDouble(Term.Text) > 0)
                {
                    switch (PickerPayment)
                    {
                        case 0:
                            double monthlyInterestRate = interestRate / 1200; // перевод процентной ставки в месячную долю
                            double annuityFactor = monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, int.Parse(loanTermInMonths)) / (Math.Pow(1 + monthlyInterestRate, int.Parse(loanTermInMonths)) - 1); // вычисляем коэффициент аннуитета
                            double annuityPayment = Math.Round(double.Parse(loanAmount) * annuityFactor, 2); // вычисляем ежемесячный платеж

                            MonthlyPaymentLabel.Text = $"Ежемесячный платеж: {annuityPayment}";
                            TotalLabel.Text = $"Общая сумма: {Math.Round(annuityPayment, 2) * int.Parse(loanTermInMonths)}";
                            OverpaymentLabel.Text = $"Переплата: {Math.Round(Math.Round(annuityPayment, 2) * int.Parse(loanTermInMonths) - Math.Round(double.Parse(loanAmount), 2), 2)}";
           
                            break;
                        case 1:
                            MonthlyPaymentLabel.Text = "Ежемесячный платеж: ...";
                            TotalLabel.Text = "Общая сумма: ...";
                            OverpaymentLabel.Text = "Переплата: ...";
                            break;
                        default:
                            MonthlyPaymentLabel.Text = "Ежемесячный платеж: N/A";
                            TotalLabel.Text = "Общая сумма: N/A";
                            OverpaymentLabel.Text = "Переплата: N/A";
                            break;
                    }
                }
            } catch
            {

            }
        }
    }
}