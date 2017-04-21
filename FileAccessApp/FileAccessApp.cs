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

namespace FileAccessApp
{
    public partial class FrmFileAccess : Form
    {
        public FrmFileAccess()
        {
            InitializeComponent();
        }

        private void FrmFileAccess_Load(object sender, EventArgs e)
        {
            lstBoxItmsToDisp.Text = "";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            lstBoxItmsToDisp.Items.Clear();
            string inValue;

            try
            {
                using (StreamReader input = new StreamReader("name.txt"))
                {
                    while ((inValue = input.ReadLine()) != null)
                    {
                        //Add text read from the file to the listBox object on the form
                        lstBoxItmsToDisp.Items.Add(inValue);
                    }
                }

                lblWarning.ForeColor = Color.Purple;
                lblWarning.Text = "File read Successfully!";
            }
            catch (FileNotFoundException exc)
            {
                lblWarning.ForeColor = Color.Red;
                lblWarning.Text = "The file was not found\n" + exc.Message;
            }
            catch (Exception exc)
            {
                lblWarning.Text = exc.Message;
            }
        }
    }
}
