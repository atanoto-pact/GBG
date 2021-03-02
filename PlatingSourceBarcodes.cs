using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BioSero.GreenButtonGo.Scripting;

namespace GreenButtonGo.Scripting
{
    public class PlatingSourceBarcode : BioSero.GreenButtonGo.GBGScript
    {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo)
        {
            //=======GETTING/SETTING NECESARRY VARIABLES==========
        
            //Grab variables to be used at runtime. 
            bool IsAltSource = (bool)variables["QPix.Is Alt Source"];
            string Barcode = (string)variables["Barcode"];
            string PlateOnAltSource = (string)variables["Plate On QPix Alt Source"];
            //============================================
            
            
            // Define regex with search pattern of two barcodes separated by a comma
            Regex regex = new Regex(@"(\w+),(\w+)");
            
            Match match = regex.Match(Barcode);
            
            // Logic for handling Alternating Plating
            if(match.Success)
            {
                variables["Barcode.PlatingSource2"] = match.Groups[2].Value;  // Plate on Dest
                variables["Barcode.PlatingSource1"] = match.Groups[1].Value;  // Plate on Alt Source
            }
            else
                variables["Barcode.PlatingSource1"] = Barcode;
            
            // Checks if using Alternating Plating
            if (IsAltSource)
            {
                variables["Plate On QPix Alt Source"] = match.Groups[1].Value;
                variables["Plate On QPix Destination"] = match.Groups[2].Value;
            }
            else
            {
                variables["Plate On QPix Destination"] = Barcode;
            }

        }
    }
}
