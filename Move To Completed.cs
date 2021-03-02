using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BioSero.GreenButtonGo.Scripting;

namespace GreenButtonGo.Scripting
{
    public class Move_To_Completed : BioSero.GreenButtonGo.GBGScript
    {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo)
        {

            string dest = @"\\MolecularDevice\Qpix\thirdparty-identifiers\output\Completed";
            foreach (var file in Directory.EnumerateFiles(@"\\MolecularDevice\Qpix\thirdparty-identifiers\output"))
            {
            string destFile = Path.Combine(dest, Path.GetFileName(file));
            if(!File.Exists(destFile))
                File.Move(file, destFile);
            }

        }
    }
}
