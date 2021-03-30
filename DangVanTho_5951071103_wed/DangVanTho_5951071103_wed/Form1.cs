using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangVanTho_5951071103_wed
{
    public partial class Form1 : Form
    {
        const string APPID = "2b1a56ed9325f249be33d150f046db42";
        string cityID = "1566083";
        
        public Form1()
        {
            InitializeComponent();
            getWeather("1566083");
            geForcast("1566083");


        }


        void getWeather(string city)
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&appid={1}&units=metric&cnt=6", city, APPID);
                var json = web.DownloadString(url);

                var resuilt = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                WeatherInfo.root outPut = resuilt;

                lbl_textCity.Text = string.Format("{0}", outPut.name);
                lbl_Country.Text = string.Format("{0}", outPut.sys.country);
                lbl_DoCE.Text = string.Format("{0} \u00B0 " + "c" , outPut.main.temp);


            }

        }
        void geForcast(string city)
        {
            int day = 2;
            string url = string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?id={0}&units=metric&cnt={1}&appid={}", city, day, APPID); ;
            using (WebClient web = new WebClient())
            {
                var json = web.DownloadString(url);

                var Object = JsonConvert.DeserializeObject<WeatherForcasts>(json);
                WeatherForcasts forcasts = Object;

                lbl_Con.Text = string.Format("{0}", forcasts.list[1].wearther[0].main);
                lbl_Des.Text = string.Format("{0}", forcasts.list[1].wearther[0].descriptions);
                lbl_Des2.Text = string.Format("{0}\u00B0 " + "c", forcasts.list[1].temp);
                lbl_speed.Text = string.Format("{0}", forcasts.list[1].speed);










            }

        } 

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
