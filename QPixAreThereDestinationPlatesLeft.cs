using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BioSero.GreenButtonGo.Scripting;

namespace GreenButtonGo.Scripting
{
    public class QPixAreThereDestinationPlatesLeft : BioSero.GreenButtonGo.GBGScript
    {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo)
        {
            var rows = Database.GetAllRows("Plate_Storage_Hotels", new[] { "Barcode", "Zone", "Has_Been_Run" });
            bool result = rows.Any(r => !string.IsNullOrWhiteSpace(r[0]) && r[1] == "Destination" && r[2] == "False");
            variables["Result"] = result;

        }
    }
}
