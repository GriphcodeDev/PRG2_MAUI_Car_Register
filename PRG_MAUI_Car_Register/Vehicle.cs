using System.Text.RegularExpressions;

namespace PRG_MAUI_Car_Register
{
    class Vehicle
    {
        // Medlemsvariabler
        public enum Type { Bil, MC, Lastbil };
        private Type vehicleType;
        private string registrationNumber = string.Empty;
        
        private string manufacturer = string.Empty;
        private string model = string.Empty;
        private int yearModel;

        public String[] CarList = new string[] { "Volvo", "BWM", "Audi", "Ferrari", "Porsche" };

      
        public Vehicle(Type vehicleType)
        {
            this.vehicleType = vehicleType;

        }

        public string RegistrationNumber
        {
            get { return registrationNumber; }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Ett registreringsnummer måste skrivas in");
                }
                 
                if (!Regex.IsMatch(value, @"^[A-Za-z]{3}[0-9]{2}[A-Za-z0-9]$"))
                {
                    throw new ArgumentException("Ett registreringsnummer måste bestå av tre bokstäver följt av två siffror och en siffra eller bokstav.");
                }

                registrationNumber = value.ToUpper();
            }
        }

        public Type VehicleType
        {
            get { return vehicleType; }
            set { this.vehicleType = value; }
        }

        public string Model
        {
            get { return model; }
            set 
            {
                Validatename(value, "Modell");
                model = value.Trim();
            
            } 
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set 
            {
                Validatename(value, "Märke");
                manufacturer = value.Trim();
            }
        }

        public int YearModel
        {
            get { return yearModel; }
            set {

                if (!Regex.IsMatch(value.ToString(), @"^[1-2][0-9]{3}\z"))
                {
                    throw new ArgumentException("Årsmodellen måste vara ett fyrsiffrigt tal."); 
                }

                if (value < 1895 || value > DateTime.Now.Year) {

                    throw new ArgumentException($"Årsmodellen måste vara mellan året 1895 och {DateTime.Now.Year}");
                }

                yearModel = value;
            
            }
        }

        private static void Validatename(string value, string fieldName)
        {
            if(String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{fieldName} måste skrivas in");
            }

            string trimmed = value.Trim();
            bool hasLetterOrDigit = false;

            foreach (char c in trimmed)
            {
                if (char.IsLetter(c) || char.IsDigit(c))
                {
                    hasLetterOrDigit = true;
                }
                else if (c != ' ' && c != '-')
                {
                    throw new ArgumentException($"{fieldName} får inte innehålla specialtecken");
                }
            }
        }


        public override string ToString()
        {
            return this.registrationNumber + "\t" + this.vehicleType + "\t" + this.manufacturer + "\t" + this.model + "\t" + this.yearModel.ToString();
        }
    }
}
