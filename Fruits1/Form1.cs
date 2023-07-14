using Fruits1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fruits1
{
    public partial class Form1 : Form
    {
        
            DbFruits db = null;
            public Form1()
            {
                InitializeComponent();
                db = new DbFruits();
             //   comboBox1.DataSource = db.GetFruktiki();
              //  comboBoxFaculty.DisplayMember = "Name";
        }
        List<Vegan> list = new List<Vegan>();
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            listBox1.DataSource = null; 

        }
     
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox2.SelectedItem.ToString();

            // Выполняем действия на основе выбранного элемента
            switch (selectedValue)
            {
                case "Show ALL":
                    
                    listBox1.DataSource = db.GetFruktiki();
                    break;
                case "Показать названия овощей и фруктов":
                  
                   listBox1.DataSource = db.GetFruktiki();
                    listBox1.DisplayMember = "name";
                    break;
                case "Показать максимальную калорийность":

                    textBox1.Text = db.MaxC().ToString();
                    break;
                case "Показать минимальную калорийность":
                    textBox1.Text = db.MinC().ToString(); 
                    break;
                case "Показать среднюю калорийность":
                    textBox1.Text = db.AvgC().ToString(); 
                    break;
                case "Показать количество овощей":
                    textBox1.Text = db.CountV().ToString();
                    break;
                case "Показать количество фруктов":
                    textBox1.Text = db.CountF().ToString();
                    break;
                case "Показать овощи и фрукты с калорийностью ниже 120":

                    listBox1.DataSource = db.GetCallory2();

                    break;
                case "Показать овощи и фрукты с калорийностью выше 120":
                    listBox1.DataSource = db.GetCallory1();

                    break;
                case "Показать овощи и фрукты с калорийностью от 120 до 150":
                    listBox1.DataSource = db.GetCallory3();
                    break;
                case "Показать количество овощей фруктов каждого цвета":
                    listBox1.DataSource = db.GetQty();
                    break;
            }
          

        }

        /// Colors COMBO BOX

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem.ToString();

            switch (selectedValue)
            {
                case "yellow":
                    listBox1.DataSource = db.GetRed("yellow");
                    break;
                case "red":
                    listBox1.DataSource = db.GetRed("red");
                    break;
                  
                case "brown":
                    listBox1.DataSource = db.GetRed("brown");
                    break;
                case "white":
                    listBox1.DataSource = db.GetRed("white");
                    break;
                case "green":
                    listBox1.DataSource = db.GetRed("green");
                    break;
            }
        }







    }
}
