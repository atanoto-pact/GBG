using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BioSero.GreenButtonGo.Scripting;

namespace GreenButtonGo.Scripting
{
    public class Rename_Output : BioSero.GreenButtonGo.GBGScript
    {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo)
        {
            // Insert code here:
            string Identifiers = variables["Identifiers"] as string;  
            
         //   MessageBox.Show(Identifiers);
           string[] IdentifiersSplit= Identifiers.Split('\\');
           
           string FileName = IdentifiersSplit[5];
           
  //         MessageBox.Show(FileName);
           
           string[] FileNameSplit = FileName.Split('_');
           
           string Prefix = FileNameSplit[0];
           
 //          MessageBox.Show(Prefix);
           
           DirectoryInfo d = new DirectoryInfo(@"\\MolecularDevice\Qpix\thirdparty-identifiers\output");
            FileInfo[] infos = d.GetFiles();
            foreach(FileInfo f in infos)
{
             File.Move(f.FullName, f.FullName.Replace("QPix_",Prefix+"_QPix_"));
}
           
           
           }
           }
           }
