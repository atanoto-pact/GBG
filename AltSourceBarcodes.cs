using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BioSero.GreenButtonGo.Scripting;

namespace GreenButtonGo.Scripting
{
    public class AltSourceBarcode : BioSero.GreenButtonGo.GBGScript
    {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo)
        {
          //Grab variables to be used at runtime. 
           bool IsAltSource = (bool)variables["QPix.Is Alt Source"];
           string HighConcentrationBarcode = (string)variables["Plate On QPix Destination"];
           string LowConcentrationBarcode = (string)variables["Plate On QPix Alt Source"];


            if (IsAltSource)
            {
               variables["Alt Plating Barcode Pair"] = HighConcentrationBarcode + "#" + LowConcentrationBarcode;
          }

    

        }
    }
}
