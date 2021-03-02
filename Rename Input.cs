using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BioSero.GreenButtonGo.Scripting;

namespace GreenButtonGo.Scripting
{
    public class Rename_Input : BioSero.GreenButtonGo.GBGScript
    {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo)
        {
            // Insert code here:
         string IdentifiersSend = variables["Identifiers"] as string;  

           var Replacement = IdentifiersSend.Replace("\\","/");           
 
 
 Replacement = "\"" + Replacement + "\"";
 
 
 variables["IdentifiersSend"] = Replacement;
 
 
        }
    }
}
