
using SuiviCompresseur.GestionCompresseur.Data.Context;
using SuiviCompresseur.GestionCompresseur.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuiviCompresseur.GestionCompresseur.Data.Repository
{
    public class ValidationContraint
    {
        private readonly CompresseurDbContext _context;
        public ValidationContraint(CompresseurDbContext context)
        {
            _context = context;
        }
        public string testPost(Fiche_Suivi fiche_Suivi)
        {
            string result;
            int max = 0;

            var maxpossible = _context.Fiche_Suivis.Where(c => c.CompFilialeID == fiche_Suivi.CompFilialeID &&
            DateTime.Compare(fiche_Suivi.Date, c.Date) < 0).FirstOrDefault();
            if (maxpossible != null)
            {
                max = _context.Fiche_Suivis.Where(c => c.CompFilialeID == fiche_Suivi.CompFilialeID &&
                DateTime.Compare(fiche_Suivi.Date, c.Date) < 0).Max(c => c.Index_Electrique);
            }
            string datedouble = TestDoubleDate(fiche_Suivi);
            if (datedouble == "true")
            {
                int value = DateTime.Compare(fiche_Suivi.Date, DateTime.Now);
                if (value <= 0)
                {

                    if (fiche_Suivi.Date.DayOfWeek != DayOfWeek.Saturday && fiche_Suivi.Date.DayOfWeek != DayOfWeek.Sunday)
                    {
                        var exist = _context.Fiche_Suivis.Where(c => c.CompFilialeID == fiche_Suivi.CompFilialeID).FirstOrDefault();
                        if (exist != null)
                        {
                            DateTime date2;
                            int annee = fiche_Suivi.Date.Year;
                            int mois = fiche_Suivi.Date.Month - 1;
                            if (mois == 0)
                            {
                                mois = 12;
                                annee--;
                            }
                            int last = DateTime.DaysInMonth(annee, mois);
                            DateTime date = new DateTime(annee, mois, last);

                            if (date.DayOfWeek == DayOfWeek.Saturday)
                            {
                                date2 = new DateTime(annee, mois, last - 1);
                            }
                            else if (date.DayOfWeek != DayOfWeek.Sunday)
                            {
                                date2 = new DateTime(annee, mois, last - 2);
                            }
                            else
                            {
                                date2 = new DateTime(annee, mois, last);
                            }
                            var res = _context.Fiche_Suivis.Where(c => c.Date == date2).FirstOrDefault();
                            if (res != null)
                                result = "true";
                            else
                                result = "The last day of the previous month not completed";
                        }
                        else
                            result = "true";

                    }
                    else
                         result = "Week-end";
                }
                else
                    result = "Date superior to the date of today";

                if (result == "true")
                {
                    if (fiche_Suivi.Nbre_Heurs_Charge < fiche_Suivi.Nbre_Heurs_Total)
                    {
                        if (fiche_Suivi.Index_Electrique >= max)
                        {
                            return "true";
                        }
                        else
                            return "Index lower than the previous index";
                    }
                    else
                        return "Total number of hours less than the number of hours in charge";
                }
                else
                    return result;
            }
            else
                return datedouble;
        }

        public string testPut(Fiche_Suivi fiche_Suivi,Guid id)
        {
            string result;
            int value = DateTime.Compare(fiche_Suivi.Date, DateTime.Now);
            if (value <= 0)
            {

                if (fiche_Suivi.Date.DayOfWeek != DayOfWeek.Saturday && fiche_Suivi.Date.DayOfWeek != DayOfWeek.Sunday)

                {

                    DateTime date2;
                    int annee = fiche_Suivi.Date.Year;
                    int mois = fiche_Suivi.Date.Month - 1;
                    if (mois == 0)
                    {
                        mois = 12;
                        annee--;
                    }
                    int last = DateTime.DaysInMonth(annee, mois);
                    DateTime date = new DateTime(annee, mois, last);

                    if (date.DayOfWeek == DayOfWeek.Saturday)
                    {
                        date2 = new DateTime(annee, mois, last - 1);
                    }
                    else if (date.DayOfWeek != DayOfWeek.Sunday)
                    {
                        date2 = new DateTime(annee, mois, last - 2);
                    }
                    else
                    {
                        date2 = new DateTime(annee, mois, last);
                    }
                    var res = _context.Fiche_Suivis.Where(c => c.Date == date2).FirstOrDefault();
                    if (res != null)
                        result = "true";
                    else
                        result = "The last day of the previous month not completed";

                }
                else
                     result = "Week-end";
            }
            else
                result = "Date superior to the date of today";


            if (result == "true")
            {
                int max = _context.Fiche_Suivis.Where(c => c.CompFilialeID == fiche_Suivi.CompFilialeID).Max(c => c.Index_Electrique);
                if (fiche_Suivi.Nbre_Heurs_Charge < fiche_Suivi.Nbre_Heurs_Total)
                {
                    if (fiche_Suivi.Index_Electrique >= max)
                    {
                        {
                            var entity = _context.Fiche_Suivis.Find(id);
                            if (entity != null)
                            {
                                return "true";
                            }
                            else
                            {
                                return "Fiche suivi don't exist";
                            }
                        }
                    }
                    else
                        return "Index lower than the previous index";
                }
                else
                    return "Total number of hours less than the number of hours in charge";
            }
            else
                return result;
        }




        public string TestDoubleDate(Fiche_Suivi fiche_Suivi)
        {
            var doubledate = _context.Fiche_Suivis.Where(c => c.CompFilialeID == fiche_Suivi.CompFilialeID && c.Date == fiche_Suivi.Date).FirstOrDefault();
            if (doubledate == null)
                return "true";
            else
                return "Existing Fiche_suivi at this date";
        }
    }
}
