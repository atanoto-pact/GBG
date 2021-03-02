using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BioSero.GreenButtonGo.Scripting;

namespace GreenButtonGo.Scripting
{
    public class AddOffsets : BioSero.GreenButtonGo.GBGScript
    {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo)
        {
 //=======GETTING/SETTING NECESARRY VARIABLES==========
        
        //Grab variables to be used at runtime. 
        string currentLabware = (string)variables["Current Labware"];
        double dwOffset = (double)variables["QPix.DW Nest Offset"];
        double mwOffset = (double)variables["QPix.MW Nest Offset"];
        string nestLocation = (string)variables["QPix.Nest Location"];
        
        //Change these for different locations.
        string destinationNest = "QPix " + nestLocation + " Nest";
        string originalNest = "QPix " + nestLocation + " Original";
        
       //Get the  teachpoint for the correct nest.
        dynamic  pf400 = GetInstrument("PF-400");
        IEnumerable<dynamic> teachpoints = pf400.Robot.TeachPoints;
        
        //Get the original nest value. 
        double originalNestZValue = teachpoints.First(t=>t.Name == originalNest).Joint1;
        
        //Get the labware height
        double currentLabwareHeight = EdgyCode.ApplicationManager.BootStrapper.GetInstance<BioSero.GreenButtonGo.Labware.LabwareManager>().GetLabwareDefinition(currentLabware).HeightInMm;
        
//========SET THE PUT OFFSETS=========

        //If greater than 20
        if(currentLabwareHeight > 20)
            {
                //MessageBox.Show("Subtracting " + dwOffset + " from the " + destinationNest + " location.");
                teachpoints.First(t=>t.Name == destinationNest).Joint1 = originalNestZValue - dwOffset;
                //MessageBox.Show("The plate is a deep well and its height is " + currentLabwareHeight.ToString());
            }
        else if (currentLabwareHeight >15)
            {
                teachpoints.First(t=>t.Name == destinationNest).Joint1 = originalNestZValue - mwOffset;
                //MessageBox.Show("The current plate is a mid well plate and its hieght is " + currentLabwareHeight.ToString());
            }
         else
         {
                teachpoints.First(t=>t.Name == destinationNest).Joint1 = originalNestZValue; 
                //MessageBox.Show("Standard height plate at: " + currentLabwareHeight.ToString());
         }
        //MessageBox.Show(teachpoints.First(t=>t.Name == destinationNest).Joint1.ToString());                  
        }
    }
}
