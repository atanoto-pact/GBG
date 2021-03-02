using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BioSero.GreenButtonGo.Scripting;

namespace GreenButtonGo.Scripting
{
    public class Reference_Barcode : BioSero.GreenButtonGo.GBGScript
     {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo)
        {
            // Insert code here:
            List<string[]> echoTable1 = Database.GetAllRows("Identifiers_Worklist_Reference", new string[] {"Barcode"}).ToList();
 
 string ReferenceBarcode = echoTable1[0][0];

//MessageBox.Show (ReferenceBarcode);

variables["Reference Plate On QPix Source"] = ReferenceBarcode;

         
        }
    }
    
    }
