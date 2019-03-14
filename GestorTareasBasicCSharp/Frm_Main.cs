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

        //Definiendo las Variables de Uso
        private bool _IsNewTask;

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

            this._IsNewTask = true;
        }

        private void SaveTask()
        {
            if (_IsNewTask)
            {
                this.lstTask.Items.Add(this.txtTask.Text);
                this.btnAdd.Enabled = true;
            } else {
                this.lstTask.Items[this.lstTask.SelectedIndex] = txtTask.Text;
            }
            
            Resec();
        }

        private void LoadSelectedTask()
        {
            if (lstTask.SelectedIndex >= 0 && lstTask.SelectedIndex < lstTask.Items.Count){
                this.txtTask.Text = lstTask.Items[lstTask.SelectedIndex].ToString();
                this.btnAdd.Enabled = false;
                this.btnCancel.Enabled = true;
                this.btnSave.Enabled = true;
                this.btnDelete.Enabled = true;
                this.txtTask.Enabled = true;

                this._IsNewTask = false;
            }
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
            this.LoadSelectedTask();
        }
    }
}
