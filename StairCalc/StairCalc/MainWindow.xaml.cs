﻿using System;
using System.Linq;
using System.Windows;
//Added
using System.IO;
using System.Diagnostics;

//Staircalc 3.
//A simple program that calculates the going rise and angle of stairs.
//Written by David Mathew Cornelius.
namespace StairCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Date.Text = (string.Format("{0:dddd MMMM dd yyyy}", DateTime.Now));
        }
        private void calc(object sender, RoutedEventArgs e)
        {
            string address = this.PropAdd.Text;                                  //Get property name      
            string inputDim = (this.Input.Text);                                //Get the string of the number
            string dim = String.Concat(inputDim.Where(Char.IsDigit));           //Strip out anything that is not a number 
            if (address == "")
            { address = " (there was no address stated)"; }
            if (dim == "")
            {
                Messages.missing();
                Input.Clear();
                return;
            }
            //Start calculation
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int dimint = Convert.ToInt32(dim);                                        //Convert String to integer
            int ris = Tables.riserTable(dimint);                                        //Using riserTable method of the Tables class
            if (dimint < 440 || dimint > 3300)
            {
                Messages.boundrys();
                return;
            }
            int risDim = (dimint / ris);
            int toGo = Tables.totalGoing(risDim, ris);                                   //Using totalGoing method of the Tables class
            int Go = Tables.inividualGoing(risDim);                                      //Using inividualGoing method of the Tables class
            int bot = Tables.bottom(risDim, ris);                                         //Using bottom method of the Tables class
            double strLen = Math.Round(Math.Sqrt((dimint * dimint) + (toGo * toGo)), 3);  //Calculate string length
            double hyp = (Math.Sqrt((dimint * dimint) + (bot * bot)));                    //Calculate hyptenuse
            double angCalc = (dimint / hyp);
            double radian = (Math.Asin(angCalc));                                        //Calculate angle
            double degree = Math.Round((radian * 180 / Math.PI), 3);                     //Convert radian to string
            //System.Threading.Thread.Sleep(300);                                                                       
            timer.Stop();                                                                //Time format 0:dddd/MM/yyyy

            Results.Text = "The address of the property is " + (address) + Environment.NewLine + Environment.NewLine //Print the results
            + "You stated the finish floor to finish floor is " + (dim) + " mm" + Environment.NewLine
            + "You need  " + (ris.ToString()) + " risers " + Environment.NewLine
            + "The individual rise will be " + (risDim.ToString()) + " mm" + Environment.NewLine
            + "The individual going will be " + (Go.ToString()) + " mm" + Environment.NewLine
            + "The total going will be " + (toGo.ToString()) + " mm" + Environment.NewLine
            + "The string length will be " + (strLen.ToString()) + " mm" + Environment.NewLine
            + "The angle of the stairs will be " + (degree.ToString()) + " degrees";
            time.Text = "Excecution took " + (timer.Elapsed) + " Milliseconds";
        }
          private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Results.Clear();
            Input.Clear();
            PropAdd.Clear();
        }
          public void SaveData_Click(object sender, RoutedEventArgs e)
        {
        Retry:  
            bool saveTicket = false;
            if (Results.Text == "")
            {
                Messages.noData();
            }
            else
                {
                Microsoft.Win32.SaveFileDialog stairResult = new Microsoft.Win32.SaveFileDialog();   //Save Results textbox content if requested
                stairResult.FileName = "property";
                stairResult.DefaultExt = "*.rtf";
                stairResult.Filter = "RTF Files|*.rtf";

                // stairResult.DefaultExt = ".text"; 
                //  stairResult.Filter = "Text documents (.txt)|*.txt"; 
                Nullable <bool> result = stairResult.ShowDialog();
                 
                try
                {
                    using (StreamWriter stream = new StreamWriter(stairResult.FileName))
                    {
                        stream.Write("Generated by Staircalc on ");
                        stream.WriteLine(Date.Text);
                        stream.WriteLine("--------------------------------------------------->");
                        stream.WriteLine(Results.Text);
                        stream.WriteLine();
                        stream.WriteLine("Thankyou for using Staircalc");
                        stream.Write("Written by David Mathew Cornelius in 2013");
                        stream.Close();
                        saveTicket = true;
                    }
                }                                                                                                     //Insert data into file
                catch (Exception) 
                {
                    Messages.fileInUse();
                if (result == true)
                    {   
                        string filename = stairResult.FileName;
                    }
                    if (saveTicket == false){goto Retry;}
                    }
                MessageBoxResult saved = MessageBox.Show("Would you like To do another calculation?",
                "Staircalc 3", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (saved == MessageBoxResult.Yes)
                    {
                        Results.Clear();
                        Input.Clear();
                        PropAdd.Clear();
                        return;
                    }
                    else
                    { System.Environment.Exit(0); }
              }
        }
            public void Close_Click(object sender, RoutedEventArgs e)
        {
            Messages.exit(Results.Text);
        }
    }
}
