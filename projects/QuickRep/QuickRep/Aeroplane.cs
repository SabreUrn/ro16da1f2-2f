using System.Collections.Generic;

namespace QuickRep
{
    // En KLASSE repræsenterer en entitet i vores system. Det kan
    // være en entitet fra vores domæne, eller en entitet i vores
    // applikation (f.eks. en dialog)
    // En klasse-definition rummer:
    // 1) Instance fields
    // 2) Constructor
    // 3) Properties
    // 4) Metoder

    public class Aeroplane
    {
        #region Instance fields
        // INSTANCE FIELDS repræsenterer et objekts samlede TILSTAND.
        // De kan have en simpel type, eller referere til andre objekter.
        // De er normalt "private", således at vi har kontrol over
        // tilgangen til dem.
        // En instance field-definition rummer:
        // 1) Access modifier (private/public), næsten altid private
        // 2) Type for instance field
        // 3) Navn for instance field (_camelCase)

        private string _manufacturer;
        private string _model;
        private int _noOfSeats;
        private int _topSpeedKMH;
        private int _noOfFlights;
        private List<Engine> _engines;
        #endregion


        #region Constructor
        // En CONSTRUCTOR har til opgave at sørge for, at et objekt af
        // denne klasse har en veldefineret og meningsfuld tilstand fra start.
        // Den initielle værdi af et instance fields kan være en parameter
        // til constructoren, eller kan få den samme værdi for alle objekter.
        // En constructor-definition rummer
        // 1) Access modifier (private/public), næsten altid public
        // 2) Navn, som ALTID er det samme som klassens navn.
        // 3) Parametre (nul, en eller flere), for hver parameter:
        //    a) type
        //    b) navn
        // 4) Constructoren krop (alle statements mellem { og })
        // Bemærk, at man kan definere mere end én constructor for en klasse.

        public Aeroplane(string manufacturer, string model, int noOfSeats,
                         List<Engine> engines, int topSpeedKmh)
        {
            // Alle disse instance fields får en individuel
            // initiel værdi, via en parameter til constructoren
            _manufacturer = manufacturer;
            _model = model;
            _noOfSeats = noOfSeats;
            _engines = engines;
            _topSpeedKMH = topSpeedKmh;

            // Dette instance field får den samme initielle værdi
            // for alle objekter
            _noOfFlights = 0;
        }
        #endregion


        #region Properties
        // En PROPERTY benyttes til at få information om en eller anden
        // del af objektets tilstand, og (undetiden) også til at ÆNDRE
        // objektets tilstand.
        // En property-definition rummer
        // 1) Access modifier (private/public)
        // 2) Type for property
        // 3) Type for property (CamelCase, stort første bogstav)
        // 4) GET-del og SET-del (mindst en af disse skal være defineret)

        // Denne property tillader os både at læse (GET) og ændre (SET)
        // denne specifikke værdi
        public int NoOfSeats
        {
            get { return _noOfSeats; }
            set { _noOfSeats = value; }
        }

        // Denne property tillader os kun at læse (GET)
        // denne specifikke værdi
        public string Manufacturer
        {
            get { return _manufacturer; }
        }

        public string Model
        {
            get { return _model; }
        }

        public int TopSpeedKmh
        {
            get { return _topSpeedKMH; }
        }

        public int NoOfFlights
        {
            get { return _noOfFlights; }
        }

        // Denne property refererer IKKE til et bagvedliggende 
        // instance field, men har en fast værdi.
        public bool IsSuperMan
        {
            get { return false; }
        }

        // Denne property refererer indirekte til et bagvedliggende 
        // instance field.
        public int NoOfEngines
        {
            get { return _engines.Count; }
        }

        // Denne property refererer IKKE til et bagvedliggende 
        // instance field, men beregnes på anden vis.
        public bool StatusOK
        {
            get
            {
                bool statusOK = true;
                foreach (Engine e in _engines)
                {
                    statusOK = statusOK && e.StatusOK;
                }
                return statusOK;
            }
        }
        #endregion


        #region Metoder
        // En METODE bruges til at få et objekt til at OPFØRE
        // sig på en bestemt måde, d.v.s. foretage en eller anden
        // form for handling.
        // En metode-definition rummer:
        // 1) Access modifier (private/public)
        // 2) Type for retur-værdi (void hvis ingen retur-værdi)
        // 3) Metodens navn (CamelCase, stort første bogstav)
        // 4) Parametre (nul, en eller flere), for hver parameter:
        //    a) type
        //    b) navn
        // 5) Metodens krop (alle statements mellem { og })

        public bool TurnOn(bool ignoreStatus)
        {
            if (StatusOK || ignoreStatus)
            {
                foreach (Engine e in _engines)
                {
                    e.TurnOn();
                }
                return true;
            }
            return false;
        }

        public void Fly()
        {
            _noOfFlights++;
        } 
        #endregion
    }
}