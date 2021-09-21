using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ContactDetails;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Threading.Tasks;


namespace ContactDetails.StaticStuff
{
    public class Constants
    {
        public static String DefaultErrorMsg = "Error - 00 : Record Could Not Be Saved";
        public static String DefaultSuccessMsg = "Success - Record Saved Successfully";
        public static String IdentityColumnQuery = "Select @@Identity";
    }
}
