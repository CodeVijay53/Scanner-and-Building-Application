using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKLS_App.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IFCFilePath { get; set; } // Store IFC model path
    }
}
