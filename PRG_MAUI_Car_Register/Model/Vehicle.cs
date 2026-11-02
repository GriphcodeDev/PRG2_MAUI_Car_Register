namespace PRG_MAUI_Car_Register.Model
{
    public abstract class Vehicle
    {
        private string registrationNumber = string.Empty;
        private string manufacturer = string.Empty;
        private string model = string.Empty;

 
       
        public Vehicle() 
        {
           
        }

 

        public string RegistrationNumber
        {
            get { return registrationNumber; }

            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    if (value.Length == 6)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (!char.IsLetter(value[i]))
                                throw new ArgumentException("Inkorrekt registreringsnummer: De första tre tecknen måste vara bokstäver.");
                        }

                        for (int i = 3; i < 6; i++)
                        {
                            if (i < 5)
                            {
                                if (!char.IsDigit(value[i]))
                                    throw new ArgumentException("Inkorrekt registreringsnummer: Det fjärde och femte tecknet måste vara siffror.");
                            }
                            else
                            {
                                if (!char.IsDigit(value[i]) && !char.IsLetter(value[i]))
                                    throw new ArgumentException("Inkorrekt registreringsnummer: Det sjätte tecknet måste vara en siffra eller en bokstav.");
                            }
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Ett registreringsnummer måste bestå av exakt 6 tecken, med tre bokstäver följt av två siffror och en siffra eller bokstav.");
                }

                registrationNumber = value.ToUpper();
            }
        }

        public string Model
        {
            get { return model; }
            set { this.model = value; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { this.manufacturer = value; }
        }

        public override string ToString()
        {
            return this.registrationNumber + "\t" + "\t" + this.manufacturer + "\t" + this.model;
        }
    }
}
