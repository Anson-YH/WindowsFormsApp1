using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = folderBrowserDialog1;
            folderBrowserDialog.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog.SelectedPath;
                Environment.SpecialFolder specialFolder = folderBrowserDialog.RootFolder;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String inputdir = textBox1.Text;
            string [] inputfiles = Directory.GetFiles(inputdir);
            string [] csvset = new string[10];
            string [] data1set = new string[10];
            string [] data2set = new string[10];
            string [] data3set = new string[10];
            string [] data4set = new string[10];
            String msg = "";
            String data = "";
            String data1 = "";
            String data2 = "";
            String data3 = "";
            String data4 = "";
            String text = "";
            float data1sum = 0;
            float data2sum = 0;
            float data1avg, data2avg = 0;
            double value = 0;
            for(int j = 0; j < inputfiles.Length; j++)
            {
                msg = inputfiles[j] + "\r\n";
                StreamReader inputfile = new StreamReader(inputfiles[j]);
                int i = 0;
                csvset = new string[10];
                data1set = new string[10];
                data2set = new string[10];
                data3set = new string[10];
                data4set = new string[10];
                data1 = "";
                data2 = "";
                data3 = "";
                data4 = "";
                data1sum = 0;
                data2sum = 0;
                data1avg = 0;
                data2avg = 0;
                text = "";
                while (!inputfile.EndOfStream)
                {
                    data = inputfile.ReadLine();
                    if (data != null) csvset[i] = data;
                    if (i == 9) i = 0;
                    else i += 1;

                }
                for (i = 0; i < csvset.Length; i++)
                {
                    data1 = "";
                    data2 = "";
                    int count = 0;
                    foreach (char w in csvset[i])
                    {
                        if (w != ',')
                        {
                            if (count == 3) data1 += w;
                            if (count == 4) data2 += w;
                            if (count == 5) data3 += w;
                            if (count == 6) data4 += w;
                        }
                        if (w == ',') count += 1;
                    }
                    data1set[i] = data1;
                    data2set[i] = data2;
                    data3set[i] = data3;
                    data4set[i] = data4;
                }
                for (i = 0; i < data1set.Length; i++)
                {
                    msg = msg + data1set[i] + "," + data2set[i] + "\r\n";
                    data1sum += float.Parse(data1set[i]);
                    data2sum += float.Parse(data2set[i]);
                }
                data1avg = data1sum / data1set.Length;
                data2avg = data2sum / data2set.Length;
                msg += "Avg:" + data1avg + "," + data2avg + "\r\n";
                Random ran = new Random();
                int r = ran.Next(0, 6);
                switch (r)
                {
                    case 0:
                        value = -0.003;
                        break;
                    case 1:
                        value = -0.002;
                        break;
                    case 2:
                        value = -0.001;
                        break;
                    case 3:
                        value = 0;
                        break;
                    case 4:
                        value = 0.001;
                        break;
                    case 5:
                        value = 0.002;
                        break;
                    case 6:
                        value = 0.003;
                        break;
                }
                double newdata1 = Math.Round(data1avg + value, 3);
                msg += "New Data: " + newdata1 + ",";
                r = ran.Next(0, 6);
                switch (r)
                {
                    case 0:
                        value = -0.003;
                        break;
                    case 1:
                        value = -0.002;
                        break;
                    case 2:
                        value = -0.001;
                        break;
                    case 3:
                        value = 0;
                        break;
                    case 4:
                        value = 0.001;
                        break;
                    case 5:
                        value = 0.002;
                        break;
                    case 6:
                        value = 0.003;
                        break;
                }
                double newdata2 = Math.Round(data2avg + value, 3);
                msg += newdata2 + "\r\n";
                text += "\r\n" + ",,," + newdata1 + "," + newdata2 + "," + data3set[0] + "," + data4set[0];
                inputfile.Close();
                FileInfo outputfileinfo = new FileInfo(inputfiles[j]);
                StreamWriter outputfile = outputfileinfo.AppendText();
                outputfile.WriteLine(text);
                outputfile.Flush();
                outputfile.Close();
                //MessageBox.Show(msg);
            }
            MessageBox.Show("Finish!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
