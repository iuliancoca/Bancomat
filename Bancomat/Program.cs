using System;

public class titularCard
{
    String nrCard;
    int pin;
    String nume;
    String prenume;
    double balanta;

    public titularCard(string nrCard, int pin, string nume, string prenume, double balanta)
    {
        this.nrCard = nrCard;
        this.pin = pin;
        this.nume = nume;
        this.prenume = prenume;
        this.balanta = balanta;
    }

    public string getNr()
    {
        return nrCard;
    }

    public int getPin()
    {
        return pin;
    }

    public string getNume()
    {
        return nume;
    }

    public string getPrenume()
    {
       return prenume;
    }

    public double getBalanta()
    {
        return balanta;
    }

    public void setNr(String newNrCard)
    {
       nrCard = newNrCard;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setNume(String newNume)
    {
        nume = newNume; 
    }

    public void setPrenume(String newPrenume)
    {
        prenume = newPrenume;   
    }

    public void setBalanta(double newBalanta)
    {
        balanta = newBalanta;
    }

    public static void Main(String[] args)
    {
        void Optiuni()
        {
            Console.WriteLine("Alege una din urmatoarele optiuni...");
            Console.WriteLine("1. Balanta");
            Console.WriteLine("2. Retragere");
            Console.WriteLine("3. Depozit");
            Console.WriteLine("4. Iesire");
        }

        void balanta(titularCard utilizator)
        {
            Console.WriteLine("Balanta ta este: " + utilizator.getBalanta());
        }

        void retragere(titularCard utilizator)
        {
            Console.WriteLine("Introduceti suma pe care doriti sa o retrageti...");
            double retragere = Double.Parse(Console.ReadLine());
            if(retragere > utilizator.getBalanta())
            {
                Console.WriteLine("ATENTIE! Balanta ta este mai mica decat retragerea!!!");
                Console.WriteLine("Balanta ta este: " + utilizator.getBalanta());
            }
            else
            {
                utilizator.setBalanta(utilizator.getBalanta() - retragere);
                Console.WriteLine("Noua ta balanta este: " + utilizator.getBalanta());
            }
        }

        void depozit(titularCard utilizator)
        {
            Console.WriteLine("Introduceti suma pe care doriti sa o depozitati...");
            double depozit = Double.Parse(Console.ReadLine());
            utilizator.setBalanta(utilizator.getBalanta() + depozit);
            Console.WriteLine("Noua ta balanta este: " + utilizator.getBalanta()) ;
        }

        List<titularCard> titulariCard = new List<titularCard>();
        titulariCard.Add(new titularCard("2589450885", 5765, "COCA", "IULIAN", 3575.25));
        titulariCard.Add(new titularCard("8474964977", 2534, "COCA", "MIRCEA", 7023.66));
        titulariCard.Add(new titularCard("7437284959", 9613, "COCA", "ALEX", 263.77));
        titulariCard.Add(new titularCard("4847392847", 5214, "COCA", "MANUELA", 5024.01));
        titulariCard.Add(new titularCard("5654353454", 3437, "COCA", "ADELA", 6024.50));

        Console.WriteLine("Bine ati venit la Bancomat!");
        Console.WriteLine("Introduceti cardul dvs.");
        String nrCardCurent = "";
        titularCard utilizator;

        while (true)
        {
            try
            {
                nrCardCurent = Console.ReadLine();
                utilizator = titulariCard.Find(x => x.nrCard == nrCardCurent);
                if (utilizator != null)
                { 
                    break;
                }
                else
                {
                    Console.WriteLine("Cardul dvs nu este recunoscut! Va rugam incercati din nou...");
                }
            }
            catch 
            {
                Console.WriteLine("Cardul dvs nu este recunoscut! Va rugam incercati din nou...");
            }
        }

        Console.WriteLine("Introduceti pin-ul dvs.");
        int pinUtilizator = 0;

        while (true)
        {
            try
            {
                pinUtilizator = int.Parse(Console.ReadLine());
                if (utilizator.getPin() == pinUtilizator)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("ATENTIE! PIN INCORECT! Va rugam incercati din nou...");
                }
            }
            catch
            {
                Console.WriteLine("ATENTIE! PIN INCORECT! Va rugam incercati din nou...");
            }
        }

        Console.WriteLine("Bine ai venit, " + utilizator.getNume() + " " + utilizator.getPrenume() + "!");
        int optiune = 0;

        do
        {
            Optiuni();

            try
            {
                optiune = int.Parse(Console.ReadLine());
            }
            catch { }

            switch(optiune)
            {
                case 1: balanta(utilizator); break;
                case 2: retragere(utilizator); break;
                case 3: depozit(utilizator); break;
                case 4: break;
            }
        }
        while (optiune != 4);
        Console.WriteLine("Multumim! O zi frumoasa!");

    }
}