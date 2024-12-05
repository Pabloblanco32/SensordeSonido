using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace SensordeSonido
{
    public partial class Form1 : Form
    {
        SerialPort SerialPort;
        PictureBox[] leds;
        public Form1()
        {
            InitializeComponent();
            SerialPort = new SerialPort("COM3",9600);
            SerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            leds = new PictureBox[] { pictureBox1,
                pictureBox2,
                pictureBox3,
                pictureBox4,
                pictureBox5,
                pictureBox6,
                pictureBox7,
                pictureBox8,
                pictureBox9,
                pictureBox10,
                pictureBox11,
                     };
                             
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!SerialPort.IsOpen)
            {
                SerialPort.Open();
            }

        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        { string data=SerialPort.ReadLine();
            this.Invoke(new Action(() => UpdateLEDs(data)));}

        private void UpdateLEDs(string data)
        {for(int i = 0; i < leds.Length; i++) {
                leds[i].BackColor = data[i] == '1'?Color.Green:Color.Red;
            }
        }

    }
    
}
