using System;

public class factura
{
    string serieFactura;
    double numerar;

    public factura(string serieFactura, double numerar)
    {
        this.serieFactura = serieFactura;
        this.numerar = numerar;
    }

    public string getSerieFactura()
    {
        return serieFactura;
    }

    public double getNumerar()
    {
        return numerar;
    }

    public void setSerieFactura(string newSerieFactura)
    {
        this.serieFactura = newSerieFactura;
    }

    public void setNumerar(double newNumerar)
    {
        this.numerar = newNumerar;
    }
}


public class titularCard
{
    string nrCard;
    int pin;
    string nume;
    string prenume;
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

    public void setNr(string newNrCard)
    {
       nrCard = newNrCard;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setNume(string newNume)
    {
        nume = newNume; 
    }

    public void setPrenume(string newPrenume)
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
            Console.WriteLine("4. Transfer");
            Console.WriteLine("5. Plati facturi");
            Console.WriteLine("6. Iesire");
        }

        void balanta(titularCard utilizator)
        {
            Console.WriteLine("Balanta ta este: " + utilizator.getBalanta());
        }

        void retragere(titularCard utilizator)
        {
            Console.WriteLine("Introduceti suma pe care doriti sa o retrageti...");
            try
            {
                double retragere = Double.Parse(Console.ReadLine());
                if (retragere > utilizator.getBalanta())
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
           catch
            {
                Console.WriteLine("INTRODU CIFRE, nu altceva!!!");
            }
        }

        void depozit(titularCard utilizator)
        {
            Console.WriteLine("Introduceti suma pe care doriti sa o depozitati...");
            try
            {
                double depozit = Double.Parse(Console.ReadLine());
                utilizator.setBalanta(utilizator.getBalanta() + depozit);
                Console.WriteLine("Noua ta balanta este: " + utilizator.getBalanta());
            }
            catch
            {
                Console.WriteLine("INTRODU CIFRE, nu altceva!!!");
            }
        }

        List<titularCard> titulariCard = new List<titularCard>();
        titulariCard.Add(new titularCard("2589450885", 5765, "COCA", "IULIAN", 3575.25));
        titulariCard.Add(new titularCard("8474964977", 2534, "COCA", "MIRCEA", 7023.66));
        titulariCard.Add(new titularCard("7437284959", 9613, "COCA", "ALEX", 263.77));
        titulariCard.Add(new titularCard("4847392847", 5214, "COCA", "MANUELA", 5024.01));
        titulariCard.Add(new titularCard("5654353454", 3437, "COCA", "ADELA", 6024.50));

        void transfer(titularCard utilizator)
        {
            Console.WriteLine("Introduceti nr. cardului utilizatorului caruia ii veti transfera banii:");
            string nrCardDestinatar = Console.ReadLine();
            titularCard altUtilizator;
            altUtilizator = titulariCard.Find(x => x.nrCard == nrCardDestinatar);
            if (altUtilizator == null)
            {
                Console.WriteLine("Acest card de debit nu exista! Va rugam incercati din nou.");
            }
            else if (utilizator.nrCard == altUtilizator.nrCard)
            {
                Console.WriteLine("ATENTIE! NU iti poti transfera singur bani!");
            }
            else if (altUtilizator != null)
            {
                Console.WriteLine("Introduceti suma pe care o transferati catre " + altUtilizator.getNume() + " " + altUtilizator.getPrenume() + ".");
                try
                {
                    double transfer = Double.Parse(Console.ReadLine());
                    Console.WriteLine("Sunteti sigur ca transferati " + transfer + " catre " + altUtilizator.getNume() + " " + altUtilizator.getPrenume() + "?");
                    int optiuneTransfer = 0;
                    Console.WriteLine("Daca DA, apasa tasta 1. Daca NU, apasa pe oricare alta.");
                    optiuneTransfer = int.Parse(Console.ReadLine());
                    if (optiuneTransfer == 1)
                    {
                        Console.WriteLine("Transferul a fost realizat cu succes!");
                        utilizator.setBalanta(utilizator.getBalanta() - transfer);
                        altUtilizator.setBalanta(altUtilizator.getBalanta() + transfer);
                        Console.WriteLine("Noua ta balanta este: " + utilizator.getBalanta());
                        Console.WriteLine("Noua balanta a lui " + altUtilizator.getNume() + " " + altUtilizator.getPrenume() + " este: " + altUtilizator.getBalanta());
                    }
                }
               catch
                {
                    Console.WriteLine("INTRODU CIFRE, nu altceva!!!");
                }
            }
        }

        List<factura> facturi = new List<factura>();
        facturi.Add(new factura("FACT8429272953", 175.25));
        facturi.Add(new factura("FACT3534546466", 184.26));
        facturi.Add(new factura("FACT5469439493", 233.14));
        facturi.Add(new factura("FACT2312312534", 378.66));
        facturi.Add(new factura("FACT5656544213", 425.64));

        void plataFactura(titularCard utilizator)
        {
            Console.WriteLine("Introduceti seria facturii pe care doriti sa o achitati:");
            string serieFacturaCurenta = Console.ReadLine();
            factura serieFact;
            serieFact = facturi.Find(x => x.getSerieFactura() == serieFacturaCurenta);

            if (serieFact != null)
            {
                Console.WriteLine("Sunteti sigur ca doriti sa achitati factura " + serieFacturaCurenta + " in valoare de " + serieFact.getNumerar() + "?");
                try
                {
                    int optiunePlata = 0;
                    Console.WriteLine("Daca DA, apasa tasta 1. Daca NU, apasa pe oricare alta.");
                    optiunePlata = int.Parse(Console.ReadLine());
                    if (optiunePlata == 1)
                    {
                        facturi.RemoveAll(x => x.getSerieFactura() == serieFacturaCurenta);
                        Console.WriteLine("Plata facturii a fost realizata cu succes!");
                        utilizator.setBalanta(utilizator.getBalanta() - serieFact.getNumerar());
                        Console.WriteLine("Noua ta balanta este: " + utilizator.getBalanta());
                    }
                }
                catch
                {
                    Console.WriteLine("INTRODU CIFRE, nu altceva!!!");
                }
            }
            else
            {
                Console.WriteLine("Seria facturii nu exista! Va rugam incercati din nou.");
            }
        }

        Console.WriteLine("Bine ati venit la Bancomat!");
        Console.WriteLine("Introduceti cardul dvs.");
        string nrCardCurent = "";
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
                case 4: transfer(utilizator); break;
                case 5: plataFactura(utilizator); break;
                case 6: break;
                default: Console.WriteLine("Alege una din cele 6 optiuni!"); break;
            }
        }
        while (optiune != 6);
        Console.WriteLine("Multumim! O zi frumoasa!");
    }
}