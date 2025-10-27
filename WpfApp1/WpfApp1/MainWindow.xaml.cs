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
            double weightKg = 0, weightLb = 0;
            double heightCm = 0, heightInches = 0, heightFeet = 0;
            double waist = 0, hips = 0;
            int age = 0;

            double.TryParse(WeightKgTextBox.Text, out weightKg);
            double.TryParse(WeightLbTextBox.Text, out weightLb);
            double.TryParse(HeightCmTextBox.Text, out heightCm);
            double.TryParse(HeightInchesTextBox.Text, out heightInches);
            double.TryParse(HeightFeetTextBox.Text, out heightFeet);
            double.TryParse(WaistCmTextBox.Text, out waist);
            double.TryParse(HipsCmTextBox.Text, out hips);
            int.TryParse(AgeTextBox.Text, out age);

            string gender = "";
            if (FemaleRadioButton.IsChecked == true)
                gender = "Kobieta";
            else if (MaleRadioButton.IsChecked == true)
                gender = "Mężczyzna";

            double heightM = heightCm > 0 ? heightCm / 100 :
                             heightInches > 0 ? heightInches * 0.0254 :
                             heightFeet > 0 ? heightFeet * 0.3048 : 0;

            double bmi = 0;
            if (weightKg > 0 && heightM > 0)
                bmi = weightKg / (heightM * heightM);
            else if (weightLb > 0 && heightM > 0)
                bmi = (weightLb / 2.20462) / (heightM * heightM);

            string bmiCategory = "";
            string tip = "";

            if (bmi < 18.5) { bmiCategory = "Niedowaga"; tip = "Zadbaj o zbilansowaną dietę."; }
            else if (bmi < 25) { bmiCategory = "Waga prawidłowa"; tip = "Tak trzymaj!"; }
            else if (bmi < 30) { bmiCategory = "Nadwaga"; tip = "Zwiększ aktywność fizyczną."; }
            else { bmiCategory = "Otyłość"; tip = "Skonsultuj się z dietetykiem."; }

            ResultTextBlock.Text = $"BMI: {bmi:F2} - {bmiCategory}";
            TipTextBlock.Text = tip;

            if (waist > 0 && hips > 0)
            {
                double whr = waist / hips;
                string whrCategory = "";

                if (gender == "Kobieta")
                    whrCategory = whr > 0.85 ? "Otyłość brzuszna" : "Otyłość pośladkowo-udowa";
                else if (gender == "Mężczyzna")
                    whrCategory = whr > 0.90 ? "Otyłość brzuszna" : "Otyłość pośladkowo-udowa";

                WHRResultTextBlock.Text = $"WHR: {whr:F2} - {whrCategory}";
            }
            else
            {
                WHRResultTextBlock.Text = "WHR: Brak danych";
            }

            double bmr = 0;
            if (weightKg > 0 && heightCm > 0 && age > 0)
            {
                if (gender == "Mężczyzna")
                    bmr = 10 * weightKg + 6.25 * heightCm - 5 * age + 5;
                else if (gender == "Kobieta")
                    bmr = 10 * weightKg + 6.25 * heightCm - 5 * age - 161;

                BMRResultTextBlock.Text = $"BMR: {bmr:F0} kcal/dzień";
            }
            else
            {
                BMRResultTextBlock.Text = "BMR: Brak danych";
            }
        }
    }
}
