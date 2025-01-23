using Игра.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Azino777
{
	public partial class Form1 : Form
	{
		private readonly Random random = new Random();
		public Form1()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			this.ControlBox = false;
			pictureBox1.Visible = false;
			label2.Visible = false;
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult res = MessageBox.Show("Вы уверены?","Выход из приложения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (res == DialogResult.Yes)
			{
				Application.Exit();
			}
		}
		private async Task StartCasino(TextBox textBox)
		{
			for(int i = 0; i< 5; i++)
			{
				textBox.Text = random.Next(1, 10).ToString();
				await Task.Delay(100);
				
			}
		}
		private async void button1_Click(object sender, EventArgs e)
		{
			button1.Enabled = false;
			label2.Visible = false;
			var list = new List<TextBox> { textBox1, textBox2, textBox3 };
			foreach (TextBox textBox in list)
			{
				textBox.Clear();
			}
			pictureBox1.Visible = false;

			foreach (TextBox textBox in list)
			{
				await StartCasino(textBox);
			}

			if (list.Any(item => item.Text=="7"))
			{
				pictureBox1.Visible = true;
				label2.Visible = true ;
			}
			else
			{
				MessageBox.Show("Анлак(", "Не повезло");	 
			}
			button1.Enabled = true;
			
		}
	}
}
