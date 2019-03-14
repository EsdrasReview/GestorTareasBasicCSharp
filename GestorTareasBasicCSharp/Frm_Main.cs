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
        private bool _HasChange;

        public Frm_Main()
        {
            InitializeComponent();
            Reset();
        }

        private void Reset()
        {
            this.lstTask.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            this.btnDelete.Enabled = false;
            this.txtTask.Enabled = false;
            this.txtTask.Text = "";

            this.lstTask.Enabled = this.lstTask.Items.Count > 0;
            this.lstTask.SelectedIndex = -1;
            this._HasChange = false;
        }

        private void AddNewTask()
        {
            if (_HasChange)
            {
                if (MessageBox.Show("¿Desea Guardar Cambios?", "Guardar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!this.SaveTask())
                    {
                        return;
                    }
                }
            }
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.txtTask.Enabled = true;
            this.btnAdd.Enabled = false;
            this.txtTask.Focus();
            this.txtTask.Clear();

            this._IsNewTask = true;
        }

        private bool SaveTask()
        {
            if (this.txtTask.Text.Length == 0)
            {
                MessageBox.Show("Debe de escribir un nombre para la tarea", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_IsNewTask)
            {
                this.lstTask.Items.Add(this.txtTask.Text);
                this.btnAdd.Enabled = true;
                this.Reset();
            } else {
                this.lstTask.Items[this.lstTask.SelectedIndex] = txtTask.Text;
                MessageBox.Show("Dato guardado correctamente");
            }
            return true;
        }

        private void LoadSelectedTask()
        {
            if (lstTask.SelectedIndex >= 0 && lstTask.SelectedIndex < lstTask.Items.Count){
                this.txtTask.Text = lstTask.Items[lstTask.SelectedIndex].ToString();
                this.btnCancel.Enabled = true;
                this.btnSave.Enabled = true;
                this.btnDelete.Enabled = true;
                this.txtTask.Enabled = true;

                this._IsNewTask = false;
            }
        }

        private void DeleteTask()
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el items?", "Confirmar eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (lstTask.SelectedIndex >= 0 && lstTask.SelectedIndex < lstTask.Items.Count)
                {
                    this.lstTask.Items.RemoveAt(this.lstTask.SelectedIndex);
                    this.Reset();
                }
            }
        }

        private void CancelTask()
        {
            if (_HasChange)
            {
                if (MessageBox.Show("¿Desea Guardar Cambios?", "Guardar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!this.SaveTask())
                    {
                        return;
                    }
                }
            }
            this.Reset();
            this.btnAdd.Enabled = true;
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

        private void txtTask_TextChanged(object sender, EventArgs e)
        {
            this._HasChange = true;
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Guardar Cambios?", "Guardar", MessageBoxButtons.YesNoCancel);

            if (resultado == DialogResult.Yes)
            {
                if (!this.SaveTask()){e.Cancel = true; return;}
            }
            if (resultado == DialogResult.No)
            {
               
            }
            if (resultado == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
