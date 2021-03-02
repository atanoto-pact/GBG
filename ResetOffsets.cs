using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BioSero.GreenButtonGo.Scripting;

namespace GreenButtonGo.Scripting
{
    public class ResetOffsets : BioSero.GreenButtonGo.GBGScript
    {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo)
        {
         //Get the  teachpoint for the correct nest.
        dynamic  pf400 = GetInstrument("PF-400");
        IEnumerable<dynamic> teachpoints = pf400.Robot.TeachPoints;
        //Change these for different locations.
        string destinationNest = "QPix Destination Nest";
        string originalNest = "QPix Destination Original";
         //Set destination nest to original nest value.
        teachpoints.First(t=>t.Name == destinationNest).Joint1 = teachpoints.First(t=>t.Name == originalNest).Joint1;
        //MessageBox.Show(teachpoints.First(t=>t.Name == destinationNest).Joint1.ToString());     
        
         destinationNest = "QPix Copy Nest";
         originalNest = "QPix Copy Original";
         //Set destination nest to original nest value.
        teachpoints.First(t=>t.Name == destinationNest).Joint1 = teachpoints.First(t=>t.Name == originalNest).Joint1;
        //MessageBox.Show(teachpoints.First(t=>t.Name == destinationNest).Joint1.ToString());     
        

       }
    }
}
