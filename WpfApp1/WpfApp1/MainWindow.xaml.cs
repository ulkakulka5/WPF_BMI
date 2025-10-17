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

            if (!string.IsNullOrWhiteSpace(WeightKgTextBox.Text) && !string.IsNullOrWhiteSpace(WeightLbTextBox.Text))
            {
                ResultTextBlock.Text = "Podaj tylko jedną wartość wagi.";
            }
            else if(!string.IsNullOrWhiteSpace(WeightKgTextBox.Text) && string.IsNullOrWhiteSpace(WeightLbTextBox.Text))
            {
                double.TryParse(WeightKgTextBox.Text, out weightKg);
            }
            else if (!string.IsNullOrWhiteSpace(WeightLbTextBox.Text))
            {
                double.TryParse(WeightLbTextBox.Text, out weightLb);
            }
               

            
            double heightCm = 0;
            double heightInches = 0;
            double heightFeet = 0;

            if (!string.IsNullOrWhiteSpace(HeightCmTextBox.Text) && !string.IsNullOrWhiteSpace(HeightInchesTextBox.Text) && !string.IsNullOrWhiteSpace(HeightFeetTextBox.Text))
            {
                ResultTextBlock.Text = "Podaj tylko jedną wartość wzrostu.";
            }
            else if (!string.IsNullOrWhiteSpace(HeightInchesTextBox.Text) && string.IsNullOrWhiteSpace(HeightInchesTextBox.Text) && string.IsNullOrWhiteSpace(HeightFeetTextBox.Text))
            {
                double.TryParse(HeightCmTextBox.Text, out heightCm);
            }
            else if (string.IsNullOrWhiteSpace(HeightInchesTextBox.Text) && !string.IsNullOrWhiteSpace(HeightInchesTextBox.Text) && string.IsNullOrWhiteSpace(HeightFeetTextBox.Text))
            {
                double.TryParse(HeightInchesTextBox.Text, out heightInches);

            }
            else if (string.IsNullOrWhiteSpace(HeightInchesTextBox.Text) && string.IsNullOrWhiteSpace(HeightInchesTextBox.Text) && !string.IsNullOrWhiteSpace(HeightFeetTextBox.Text))
            {
                double.TryParse(HeightFeetTextBox.Text, out heightFeet);
            }
                

            
            if (weightKg > 0)
            {
                double heightM = 0; //na metry bo podane kg

                if (heightCm > 0)
                    heightM = heightCm / 100;
                else if (heightInches > 0)
                    heightM = heightInches * 0.0254;
                else if (heightFeet > 0)
                    heightM = heightFeet * 0.3048;
                else
                {
                    ResultTextBlock.Text = "Podaj wzrost.";
                    TipTextBlock.Text = "";
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
                    TipTextBlock.Text = "";
                    return;
                }

                bmi = (weightLb / (heightIn * heightIn)) * 703; //na inch bo podane lb
            }
            else
            {
                ResultTextBlock.Text = "Podaj wagę.";
                TipTextBlock.Text = "";
                return;
            }

            
            if ((weightKg > 0 && (weightKg < 25 || weightKg > 200)) ||
                (weightLb > 0 && (weightLb < 55 || weightLb > 440)))
            {
                ResultTextBlock.Text = "Waga poza zakresem.";
                TipTextBlock.Text = "";
                return;
            }

            if ((heightCm > 0 && (heightCm < 100 || heightCm > 250)) ||
                (heightInches > 0 && (heightInches < 39 || heightInches > 98)) ||
                (heightFeet > 0 && (heightFeet < 3.3 || heightFeet > 8.2)))
            {
                ResultTextBlock.Text = "Wzrost poza zakresem.";
                TipTextBlock.Text = "";
                return;
            }

            
            string category = "";
            string suggestion = "";

            if (bmi < 18.5)
            {
                category = "Niedowaga";
                suggestion = "Zadbaj o zbilansowaną dietę i konsultuj się z dietetykiem.";
            }
            else if (bmi < 25)
            {
                category = "Waga prawidłowa";
                suggestion = "Tak dalej! Jest OK.";
            }
            else if (bmi < 30)
            {
                category = "Nadwaga";
                suggestion = "Zwróć uwagę na aktywność fizyczną i ogranicz cukry.";
            }
            else
            {
                category = "Otyłość";
                suggestion = "Rozważ zwiększenie aktywności i zmianę nawyków żywieniowych.";
            }

            
            ResultTextBlock.Text = $"BMI: {bmi:F2} - {category}";
            TipTextBlock.Text = suggestion;
        }
    }
}
