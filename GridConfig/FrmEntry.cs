using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static GridConfig.CommonClass;

namespace GridConfig
{
    public partial class FrmEntry : Form
    {
        readonly GrdItem  wrkGrd;

        public FrmEntry( string Action, ref GrdItem grd )
        {
            InitializeComponent();
            btnAction.Text = Action;
            wrkGrd = grd;

            string[] strArr = new string[] { "Quimica", "Fisica", "Economia", "Calculo", "Historia" };
            cmbDeptos.Items.AddRange(strArr);
        }

        private void FrmEntry_Load(object sender, EventArgs e)
        {
            txtNome.Text     = wrkGrd.Nome;
            txtFone.Text     = wrkGrd.Fone;
            cmbDeptos.Text   = wrkGrd.Depto;
            dtpPeriodo.Value = wrkGrd.Periodo;
            txtSalario.Text  = wrkGrd.Salario.ToString("N2");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnAction_Click(object sender, EventArgs e)
        {
            try
            {
                //  Move os dados para a classe
                wrkGrd.Nome = txtNome.Text;
                wrkGrd.Fone = txtFone.Text;
                wrkGrd.Depto = cmbDeptos.Text;
                wrkGrd.Periodo = dtpPeriodo.Value;
                wrkGrd.Salario = double.Parse(txtSalario.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            ClearMsgLabels();
            List<CritRes> cr = wrkGrd.Critica();
            if ( cr.Count > 0)
            {
                foreach ( CritRes c in cr) {
                    if ( c.Cd == false) {
                        switch ( c.FlName) {
                            case "Nome"   : lblNome.Text    = c.Msg; break;
                            case "Fone"   : lblFone.Text    = c.Msg; break;
                            case "Depto"  : lblDepto.Text   = c.Msg; break;
                            case "Salario": lblSalario.Text = c.Msg; break;
                            default:
                                 MessageBox.Show( c.Msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        }
                    }
                }
            } else {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ClearMsgLabels()
        {
            lblNome.Text  = ""; lblFone.Text    = "";
            lblDepto.Text = ""; lblSalario.Text = "";
        }
    }
}
