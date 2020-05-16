using System;

namespace BMI_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BMI and Karvonen Calculator");
            Console.WriteLine();
            Console.WriteLine("Please enter the following values for the user...");
            Console.WriteLine();

            //Variable Declarations
            double lbs = 0, inches = 0, meters = 0, kgs = 0, bmi = 0;
            int age = 0, heartRate = 0;
            string classification = "";

            //Method Calls
            inches = inputHeight(inches);
            lbs = inputWeight(lbs);
            age = inputAge(age);
            heartRate = inputHeartRate(heartRate);
            kgs = convertToKilograms(lbs);
            meters = convertToMeters(inches);
            bmi = calcBMI(kgs, meters);
            classification = bmiClassification(classification, bmi);

            //Display the results
            Console.WriteLine();
            Console.WriteLine("Results...");
            Console.WriteLine();
            Console.WriteLine("Your BMI is: " + bmi.ToString("N2") + " " + "--" + " " + classification);
            Console.WriteLine();
            Console.WriteLine("Exercise Intensity Heart Rates:");
            Console.WriteLine("Intensity" + "\t" + "Max Heart Rate");
            Console.WriteLine();

            //Karvonen Calculations
            int mhr = 220 - age;
            int hhr = mhr - heartRate;
            for (double intensity = 50; intensity <= 95; intensity += 5)
            {
                double mtz = hhr * (intensity / 100);
                double ttz = mtz + heartRate;
                Console.WriteLine(intensity + "%" + "\t" + "--" + "\t" + ttz);
            }
            Console.ReadLine();

        }

        //input for Age
        private static int inputAge(int age)
        {
            do
            {
                Console.Write("Age: ");
                string input3 = Console.ReadLine();
                try
                {
                    age = Convert.ToInt32(input3);
                    if (age <= 0)
                    {
                        Console.WriteLine("Input Invalid: Please try again.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input Invalid: Please try again.");
                }
            } while (age <= 0);
            return age;
        }

        //input for resting heart rate
        private static int inputHeartRate(int heartRate)
        {
            do
            {
                Console.Write("Resting heart rate: ");
                string input4 = Console.ReadLine();
                try
                {
                    heartRate = Convert.ToInt32(input4);
                    if (heartRate <= 0)
                    {
                        Console.WriteLine("Input Invalid: Please try again.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input Invalid: Please try again.");
                }
            } while (heartRate <= 0);
            return heartRate;
        }

        //input for weight
        private static double inputWeight(double lbs)
        {
            do
            {
                Console.Write("Weight in pounds: ");
                string input1 = Console.ReadLine();
                try
                {
                    lbs = Convert.ToDouble(input1);
                    if (lbs <= 0)
                    {
                        Console.WriteLine("Input Invalid: Please try again.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input Invalid: Please try again.");
                }
            } while (lbs <= 0);
            return lbs;
        }

        //input for height
        private static double inputHeight(double inches)
        {
            do
            {
                Console.Write("Height in inches: ");
                string input2 = Console.ReadLine();
                try
                {
                    inches = Convert.ToDouble(input2);
                    if (inches <= 0)
                    {
                        Console.WriteLine("Input Invalid: Please try again.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input Invalid: Please try again.");
                }
            } while (inches <= 0);
            return inches;
        }

        //convert height to meters
        private static double convertToMeters(double inches)
        {

            double meters;
            meters = inches / 39.37;
            return meters;
        }

        //Calculate BMI based on weight in kgs and height in meters
        private static double calcBMI(double kgs, double meters)
        {
            double bmi;
            bmi = kgs / Math.Pow(meters, 2);
            return bmi;
        }

        //Convert lbs to kgs
        private static double convertToKilograms(double lbs)
        {
            double kgs;
            kgs = lbs / 2.2046;
            return kgs;
        }

        //Determine BMI Classification
        private static String bmiClassification(String classification, double bmi)
        {

            if (bmi < 18.5)
            {
                classification = "Underweight";
            }
            else if (bmi < 25.0)
            {
                classification = "Normal";
            }
            else if (bmi < 30.0)
            {
                classification = "Overweight";
            }
            else
            {
                classification = "Obese";
            }
            return classification;
        }

    }
}
