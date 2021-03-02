using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BioSero.GreenButtonGo.Scripting;

namespace GreenButtonGo.Scripting
{
    public class Validate_Worklist_And_Storage : BioSero.GreenButtonGo.GBGScript
    {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo)
        {
            // Insert code here:
            List<string[]> echoTable1 = Database.GetAllRows("Identifiers_Worklist", new string[] {"Time"}).ToList();
            List<string[]> echoTable2 = Database.GetAllRows("Identifiers_Worklist", new string[] {"Data"}).ToList();
            
            echoTable1.AddRange(echoTable2);
           
            List<string[]> storageTable = Database.GetAllRows("Plate_Storage_Hotels", new string[] {"Barcode"}).ToList();
            foreach(var line in echoTable1)
            {
                string Barcode = line[0];
                //MessageBox.Show(sourceBarcode + "     " + destinationBarcode);
                if(!storageTable.Any(x=>x[0] == Barcode))
                {
                    throw new InvalidOperationException("Could not find a plate in storage with barcode '" + Barcode + "'");
                }
             }
            
        }
    }
}
