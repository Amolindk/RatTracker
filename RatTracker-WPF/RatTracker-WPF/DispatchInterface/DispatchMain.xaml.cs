﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RatTracker_WPF.DispatchInterface
{
	/// <summary>
	/// Interaction logic for DispatchMain.xaml
	/// </summary>
	public partial class DispatchMain : Window
	{
		private APIWorker m_ApiWorker;
		private string m_PW = "lalala"; //doing this for now as absolver has no field for password in the settings dialog
		private string m_UN = "am@drl.dk"; //temp hack for username and pw
		public DispatchMain()
		{
			InitializeComponent();

		}

		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			Thickness margin = CasesListbox.Margin;
			margin.Right = (Width / 3) * 2;
			CasesListbox.Margin = margin;
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			List<KeyValuePair<string, string>> logindata = new List<KeyValuePair<string, string>>();
			//logindata.Add(new KeyValuePair<string, string>("email", m_UN));
			//logindata.Add(new KeyValuePair<string, string>("password", m_PW));

			m_ApiWorker = new APIWorker();

			//string o = await m_ApiWorker.sendAPI("login", logindata);

			Dictionary<string, string> qd = new Dictionary<string, string>();
			qd.Add("active", "true");
			string o = await m_ApiWorker.queryAPI("rescues", qd);


			JObject jsonRepsonse = JObject.Parse(o);
			List<JToken> tokens = jsonRepsonse["data"].Children().ToList();

			string s = tokens[2].ToString();

			//Models.Api.Rat rat = JsonConvert.DeserializeObject<Models.Api.Rat>(tokens[3].ToString());
		}
	}
}
