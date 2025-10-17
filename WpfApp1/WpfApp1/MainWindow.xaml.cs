using System;
using System.Windows;

namespace BMIApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateBMI_Click(object sender, RoutedEventArgs e)
        {
            double bmi = 0;

            
            double weightKg = 0;
            double weightLb = 0;

            if (!string.IsNullOrWhiteSpace(WeightKgTextBox.Text))
                double.TryParse(WeightKgTextBox.Text, out weightKg);

            if (!string.IsNullOrWhiteSpace(WeightLbTextBox.Text))
                double.TryParse(WeightLbTextBox.Text, out weightLb);

           
            double heightCm = 0;
            double heightInches = 0;
            double heightFeet = 0;

            if (!string.IsNullOrWhiteSpace(HeightCmTextBox.Text))
                double.TryParse(HeightCmTextBox.Text, out heightCm);

            if (!string.IsNullOrWhiteSpace(HeightInchesTextBox.Text))
                double.TryParse(HeightInchesTextBox.Text, out heightInches);

            if (!string.IsNullOrWhiteSpace(HeightFeetTextBox.Text))
                double.TryParse(HeightFeetTextBox.Text, out heightFeet);

            
            if (weightKg > 0)
            {
                double heightM = 0;

                if (heightCm > 0)
                    heightM = heightCm / 100;
                else if (heightInches > 0)
                    heightM = heightInches * 0.0254;
                else if (heightFeet > 0)
                    heightM = heightFeet * 0.3048;
                else
                {
                    ResultTextBlock.Text = "Podaj wzrost.";
                    return;
                }

                bmi = weightKg / (heightM * heightM);
            }
            else if (weightLb > 0)
            {
                double heightIn = 0;

                if (heightCm > 0)
                    heightIn = heightCm / 2.54;
                else if (heightInches > 0)
                    heightIn = heightInches;
                else if (heightFeet > 0)
                    heightIn = heightFeet * 12;
                else
                {
                    ResultTextBlock.Text = "Podaj wzrost.";
                    return;
                }

                bmi = (weightLb / (heightIn * heightIn)) * 703;
            }
            else
            {
                ResultTextBlock.Text = "Podaj wagę.";
                return;
            }

            
            string category = "";
            if (bmi < 18.5)
                category = "Niedowaga";
            else if (bmi < 25)
                category = "Waga prawidłowa";
            else if (bmi < 30)
                category = "Nadwaga";
            else
                category = "Otyłość";

            ResultTextBlock.Text = $"Twoje BMI wynosi: {bmi:F2} — {category}";
        }
    }
}
