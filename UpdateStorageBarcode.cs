using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BioSero.GreenButtonGo.Scripting;

namespace GreenButtonGo.Scripting
{
    public class UpdateStorageBarcode : BioSero.GreenButtonGo.GBGScript
    {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo)
        {
            // var hotels = GetInstrument("Plate Storage");
            string barcode = (string)variables["Barcode"];
            string hotel = (string)variables["Hotel Name"];
            double shelf = (double)variables["Shelf"]; 
            string storageHotels =  "Plate_Storage_Hotels";
            bool isAltPlating = (bool)variables["QPix.Is Alt Source"];
            string CurrentInstProcess = (string)variables["Current Instrument Process"];
            string PlateOnQPixDest = (string)variables["Plate On QPix Destination"];
            string PlateOnQPixAltSource = (string)variables["Plate On QPix Alt Source"];
            

            //MessageBox.Show("barcode: " + barcode + " hotel: " + hotel + "shelf: " + shelf);    
            if (!(isAltPlating))
            {
                Database.ExecuteCommand("update Plate_Storage_Hotels set BARCODE='' where HOTEL='" + hotel + "' and shelf='" + shelf +"'");
                Database.ExecuteCommand("update Plate_Storage_Hotels set PREVIOUS_BARCODE='" + barcode + "' where HOTEL='" + hotel + "' and shelf='" + shelf +"'");
            }
            else
            {
                if (CurrentInstProcess == "Plating Source")
                {
                    Database.ExecuteCommand("update Plate_Storage_Hotels set BARCODE='' where HOTEL='" + hotel + "' and shelf='" + shelf +"'");
                    Database.ExecuteCommand("update Plate_Storage_Hotels set PREVIOUS_BARCODE='" + PlateOnQPixAltSource + "' where HOTEL='" + hotel + "' and shelf='" + shelf +"'");
                    shelf--;
                    Database.ExecuteCommand("update Plate_Storage_Hotels set BARCODE='' where HOTEL='" + hotel + "' and shelf='" + shelf +"'");
                    Database.ExecuteCommand("update Plate_Storage_Hotels set PREVIOUS_BARCODE='" + PlateOnQPixDest + "' where HOTEL='" + hotel + "' and shelf='" + shelf +"'");
                }
                else
                {
                    Database.ExecuteCommand("update Plate_Storage_Hotels set BARCODE='' where HOTEL='" + hotel + "' and shelf='" + shelf +"'");
                    Database.ExecuteCommand("update Plate_Storage_Hotels set PREVIOUS_BARCODE='" + barcode + "' where HOTEL='" + hotel + "' and shelf='" + shelf +"'");
                }
            }

        }
    }
}
