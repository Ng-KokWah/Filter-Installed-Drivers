using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GettingDrivers
{
    public partial class DriverQuery : Form
    {
        public DriverQuery()
        {
            InitializeComponent();
        }

        //for this month
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            //run cmd in the background and get the output from the command driverquery
            String drivers = RunCommands.RunCmdAndGetOutput("driverquery");

            //write to a file the contents so that it can be read later
            //if the file already exists, clear the contents before writing the new contents in
            if(FileHandling.fileExists(@"..\..\Output\output.txt") == true)
            {
                File.WriteAllText(@"..\..\Output\output.txt", String.Empty);
                FileHandling.WriteToFile(@"..\..\Output\output.txt", drivers);
            }
            else
            {
                FileHandling.WriteToFile(@"..\..\Output\output.txt", drivers);
            }
            

            //create a variable of DateTime format and find out what is today's date to create a time span later
            DateTime datetoday = DateTime.Today;
            DateTime timeOfDay = DateTime.Now;

            //read from the file
            String[] content = FileHandling.ReadFromFileEachLine(@"..\..\Output\output.txt");

            List<String> todisplay = new List<string>();
            List<String> datetodisplay = new List<string>();

            for (int i = 0; i < content.Length; i++)
            {
                if (content[i].Contains((datetoday.Year).ToString()))
                {
                    int posofyear = content[i].IndexOf((datetoday.Year).ToString());
                    String temp2;
                    if(content[i][posofyear - 4].Equals("/"))
                    {
                        temp2 = ((content[i]).Substring(posofyear - 3, 2)).TrimStart('/');
                    }
                    else
                    {
                        
                        temp2 = ((content[i]).Substring(posofyear - 3, 3)).TrimStart('/');
                    }
                    
                    String temp3 = temp2.TrimEnd('/');
                    if (temp3.Equals((datetoday.Month).ToString()))
                    {
                        String[] temp = content[i].Split(' ');
                        todisplay.Add(temp[0]);
                        int posofmonth = content[i].IndexOf((datetoday.Month).ToString());
                        String t = content[i].Substring(posofmonth-4);
                        datetodisplay.Add(t.TrimStart(' '));
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            foreach (String n in todisplay)
            {
                listBox1.Items.Add(n);
            }

            foreach(String o in datetodisplay)
            {
                listBox2.Items.Add(o);
            }

        }

        //for this year
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            String drivers = RunCommands.RunCmdAndGetOutput("driverquery");
            DateTime datetoday = DateTime.Today;
            DateTime timeOfDay = DateTime.Now;

            if (FileHandling.fileExists(@"..\..\Output\output.txt") == true)
            {
                File.WriteAllText(@"..\..\Output\output.txt", String.Empty);
                FileHandling.WriteToFile(@"..\..\Output\output.txt", drivers);
            }
            else
            {
                FileHandling.WriteToFile(@"..\..\Output\output.txt", drivers);
            }

            String[] content = FileHandling.ReadFromFileEachLine(@"..\..\Output\output.txt");

            List<String> todisplay = new List<string>();
            List<String> datetodisplay = new List<string>();

            for (int i = 0; i < content.Length; i++)
            {
                if (content[i].Contains((datetoday.Year).ToString()))
                {
                    String[] temp = content[i].Split(' ');
                    todisplay.Add(temp[0]);
                    int posofyear = content[i].IndexOf((datetoday.Year).ToString());
                    String t = content[i].Substring(posofyear-7);
                    datetodisplay.Add(t.TrimStart(' '));
                }
                else
                {
                    continue;
                }
            }

            foreach (String n in todisplay)
            {
                listBox1.Items.Add(n);
            }

            foreach (String o in datetodisplay)
            {
                listBox2.Items.Add(o);
            }
        }

        //for today
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            String drivers = RunCommands.RunCmdAndGetOutput("driverquery");
            DateTime datetoday = DateTime.Today;
            DateTime timeOfDay = DateTime.Now;

            String dateonly = datetoday.ToString("d");
            Console.WriteLine(dateonly);

            if (FileHandling.fileExists(@"..\..\Output\output.txt") == true)
            {
                File.WriteAllText(@"..\..\Output\output.txt", String.Empty);
                FileHandling.WriteToFile(@"..\..\Output\output.txt", drivers);
            }
            else
            {
                FileHandling.WriteToFile(@"..\..\Output\output.txt", drivers);
            }

            String[] content = FileHandling.ReadFromFileEachLine(@"..\..\Output\output.txt");

            List<String> todisplay = new List<string>();
            List<String> datetodisplay = new List<string>();

            for(int i=0; i<content.Length; i++)
            {
                if(content[i].Contains(dateonly))
                {
                    String[] temp = content[i].Split(' ');
                    todisplay.Add(temp[0]);
                    int posofdate = content[i].IndexOf(dateonly);
                    String t = content[i].Substring(posofdate);
                    datetodisplay.Add(t);
                }
                else
                {
                    continue;
                }
            }

            foreach(String n in todisplay)
            {
                listBox1.Items.Add(n);
            }

            foreach(String o in datetodisplay)
            {
                listBox2.Items.Add(o);
            }

        }
    }
}
