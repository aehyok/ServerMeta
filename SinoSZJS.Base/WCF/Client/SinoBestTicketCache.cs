using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.WCF.Client
{
   public class SinoBestTicketCache
    {
       private static string ticket = "";
       public static string CurrentTicket
       {
           get
           {
               return ticket;
           }
           set
           {
               ticket = value;
           }
       }
    }
}
