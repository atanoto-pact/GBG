using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BioSero.GreenButtonGo.Scripting;

namespace GreenButtonGo.Scripting
{
    public class PickingConfigureStorage : BioSero.GreenButtonGo.GBGScript
    {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo)
        {
               int sourcePlateNum = (int)variables["QPix.Source Plate Count"];
               var hotels = GetInstrument("Plate Storage");
               hotels.ClearHotels();               
               string storageHotels =  "Plate_Storage_Hotels";
               
               if(sourcePlateNum >= 44)
               {
                        MessageBox.Show("Please restart the program and enter a Source Plate Count less than 44");     
               }
               
               Database.UpdateRow(storageHotels, "Hotel", "Hotel 1", "Zone", "Destination");
               Database.UpdateRow(storageHotels, "Hotel", "Hotel 2", "Zone", "Destination");
               Database.UpdateRow(storageHotels, "Hotel", "Hotel 3", "Zone", "Destination");
               Database.UpdateRow(storageHotels, "Hotel", "Hotel 4", "Zone", "Destination");
               
               for(int i = 1; i <= sourcePlateNum; i++)
               {
                        if( i <= 22) //HOTEL 1
                        {
                                Database.ExecuteCommand("update Plate_Storage_Hotels set ZONE='Source' where HOTEL='Hotel 1' and shelf='" +i.ToString() +"'");
                        }
                        else if( i > 22 && i <= 44) //HOTEL 2
                        {
                                int shelf = i-22;
                                Database.ExecuteCommand("update Plate_Storage_Hotels set ZONE='Source' where HOTEL='Hotel 2' and shelf='" + shelf.ToString() +"'");;
                        }
        
               }
               
               hotels.FillHotels("Source", "Source_", sourcePlateNum,"STD Omnitray",false, true);
               hotels.FillHotels("Destination", "Destination_", 88-sourcePlateNum,"STD Corning",false,true);
                
        }
    }
}
