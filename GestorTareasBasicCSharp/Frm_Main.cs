using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorTareasBasicCSharp
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
            Resec();
        }

        private void Resec()
        {
            this.lstTask.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            this.btnDelete.Enabled = false;
            this.txtTask.Enabled = false;
            this.txtTask.Text = "";

            this.lstTask.Enabled = this.lstTask.Items.Count > 0;
        }

        private void AddNewTask()
        {
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.txtTask.Enabled = true;
            this.btnAdd.Enabled = false;
            this.txtTask.Focus();
        }

        private void SaveTask()
        {
            this.lstTask.Items.Add(this.txtTask.Text);
            this.btnAdd.Enabled = true;
            Resec();
        }

        private void DeleteTask()
        {

        }

        private void CancelTask()
        {

        }


        //Botones de ejecuciones de los eventos
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.AddNewTask();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.CancelTask();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveTask();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.DeleteTask();
        }

        private void Frm_Main_KeyPress(object sender, KeyPressEventArgs e){}

        private void lstTask_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
