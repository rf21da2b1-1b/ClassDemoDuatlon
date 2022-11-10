using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoDuatlonLib.model
{
    public class Duathlete
    {
        /*
         * Der er to properties med constraints Name, AgeGroup
         */
        
        // properties
        public String Name { get; set; }

        public int AgeGroup { get; set; }

        // Tjek betingelser (Constraints)
        public static bool CheckName(String name)
        {
            if (name is null || name.Trim().Length < 4)
            {
                throw new ArgumentException("name skal være mindst 4 tegn langt");
            }

            return true;
        }
        public static bool CheckAgeGroup(int ageGroup)
        {
            if (ageGroup < 1 || 4 < ageGroup)
            {
                throw new ArgumentException("Der findes kun grupperne 1,2,3 og 4");
            }

            return true;

        }

        // validerer et helt objekt
        public bool Validate()
        {
            bool ok = true;
            try
            {
                CheckName(Name);
                CheckAgeGroup(AgeGroup);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message); // eller bare throw;
            }
            return ok;
        }

        /*
         * Der er tre properties uden constraints
         */
        public int Bib { get; set; }
        public int Bike { get; set; }
        public int Run { get; set; }

        /*
         * Begregnet Property Total
         */

        public int Total // sum Bike + Run
        { 
            get
            {
                return Bike + Run;
            }
         }




        /*
         * Konstruktør
         */
        public Duathlete() : this("dummy", 1, -1, -1, -1)
        {

        }

        public Duathlete(string name, int ageGroup, int bib, int bike, int run)
        {
            Name = name;
            AgeGroup = ageGroup;
            Bib = bib;
            Bike = bike;
            Run = run;
            Validate(); // er værdierne i orden
        }



        /*
         * 
         * ToString
         */
        public override string ToString()
        {
            return $"{nameof(Name)}={Name}, {nameof(AgeGroup)}={AgeGroup}, {nameof(Bib)}={Bib}, {nameof(Bike)}={Bike}, {nameof(Run)}={Run}, Total={Total} ";
        }

    }
}
