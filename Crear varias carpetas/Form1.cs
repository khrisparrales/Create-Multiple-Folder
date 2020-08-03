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

namespace Crear_varias_carpetas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region Drag Form/ Mover Arrastrar Formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                 Crear();                
                MessageBox.Show("Las carpetas se han creado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
      
        void Crear()
        {
            switch (checkBox1.Checked)
            {
                case true:
                    string[] v = textBox1.Text.Split('\n');
                    for (int i = 0; i < v.Length; i++)
                    {
                        if (Directory.Exists(label1.Text + @"\" + (i + 1 + "-").ToString() + v[i]) == false)
                        {
                            DirectoryInfo di = Directory.CreateDirectory(label1.Text + @"\" + (i + 1 + "-").ToString() + v[i]);
                        }
                        else
                        {
                            MessageBox.Show("La carpeta " + label1.Text + @"\" + (i + 1 + "-").ToString() + v[i] + " ya existe");

                        }

                    }
                    break;
                case false:
                    string[] v2 = textBox1.Text.Split('\n');
                    for (int i = 0; i < v2.Length; i++)
                    {
                        if (Directory.Exists(label1.Text + @"\" +v2[i]) == false)
                        {
                            DirectoryInfo di = Directory.CreateDirectory(label1.Text + @"\" + v2[i]);
                        }
                        else
                        {
                            MessageBox.Show("La carpeta " +v2[i] + " ya existe");

                        }

                    }
                    break;
            }
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    label1.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
