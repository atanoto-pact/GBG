using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BioSero.GreenButtonGo.Scripting;

namespace GreenButtonGo.Scripting
{
    public class UpdateBarcodeDatatable : BioSero.GreenButtonGo.GBGScript
    {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo)
        {
             //=======GETTING/SETTING NECESARRY VARIABLES==========
        
            //Grab variables to be used at runtime. 
            string CurrentWorkcellProcess = (string)variables["Current Workcell Process"];
            string CurrentPlateProcess = (string)variables["Current Plate Process"];
            string CurrentInstProcess = (string)variables["Current Instrument Process"];
            bool IsAltSource = (bool)variables["QPix.Is Alt Source"];
            //============================================
            
            string PlateLocation = "";
            
            // Define regex with search pattern to determine if QPix is plating
            Regex rx = new Regex(@"Plating");
            
            Match match = rx.Match(CurrentInstProcess);
            
            // If the word "Plating" is found, source and destination need to be switched
            if (match.Success)
            {
                if(CurrentPlateProcess == "Source")
                    if(IsAltSource)
                        PlateLocation = "Alt Source";
                    else
                        PlateLocation = "Destination";
                else
                    PlateLocation = "Source";
            }
            else
            {
                PlateLocation = CurrentPlateProcess;
            }
            
            string Datatable = CurrentWorkcellProcess + " " + CurrentPlateProcess + " Runtime";
            
            variables["WorkcellDatatable"] = Datatable;
            variables["PF-400.OldBarcode"] = (string)variables["Plate On QPix " + PlateLocation];
            
            //string QPixTest = (string)variables["Plate On QPix " + PlateLocation];
            //MessageBox.Show(PlateLocation);   

        }
    }
}
