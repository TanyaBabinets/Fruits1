using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Drawing;
using System.Data.SqlClient;

namespace Fruits1.Model
{
    public class Vegan
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string color { get; set; }
        public int callory { get; set; }

        //public Vegan(int i, string n, string t, string col, int cal)
        //{
        //    Id = i; name = n; type = t; color = col; callory = cal;
        //}
        public override string ToString()
        {
           return $"{Id}.{name} Type: {type} Color: {color} Callory = {callory}";
 
        }
      

        
    }



}
