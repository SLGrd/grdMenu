using System;
using System.Collections.Generic;
using System.Data;

using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using static GridConfig.CommonClass;

namespace GridConfig
{
    public partial class FrmGrd : Form
    {
        private Point ClickPoint = new Point() ;

        private List<GrdItem> grdItems = new List<GrdItem>()
        {
            new GrdItem( "Joao",        "4323 2123",    "Fisica",   "01/09/16", 1500.46),
            new GrdItem( "Maria",       "9706 2123",    "Quimica",  "12/08/20", 1500.21),
            new GrdItem( "Jose",        "4323 4446",    "Calculo",  "23/07/18", 2300.92),
            new GrdItem( "Fonseca",     "5355 2123",    "Historia", "11/09/13", 1260.2),
            new GrdItem( "Joao",        "6380 2123",    "Fisica",   "05/12/17", 1543.2),
            new GrdItem( "Manoela",     "7323 2123",    "Idiomas",  "07/09/12", 6500.2),
            new GrdItem( "Joao",        "8323 6053",    "Fisica",   "03/09/11", 2500.2),
            new GrdItem( "Gabriel",     "3323 6390",    "Calculo",  "07/03/17", 4400.2),
            new GrdItem( "Jonas",       "4323 2123",    "Fisica",   "08/09/16", 4300.2),
            new GrdItem( "Venceslau",   "4323 2123",    "Economia", "12/09/13", 3500.2),
            new GrdItem( "Sabrina",     "7323 2123",    "Fisica",   "22/11/16", 4500.2),
            new GrdItem( "Afonso",      "2923 2123",    "Calculo",  "25/10/15", 1587.2),
            new GrdItem( "Cristiano",   "4323 2123",    "Biologia", "21/09/16", 5300.2),
            new GrdItem( "Riberto",     "5903 2123",    "Fisica",   "11/05/18", 1780.2),
            new GrdItem( "Luiz",        "7783 2123",    "Mecanica", "03/03/19", 3320.2),
            new GrdItem( "Joao",        "6473 2123",    "Fisica",   "14/07/10", 4215.2)
        };

        public FrmGrd() { InitializeComponent(); }

        private void FrmGrd_Load(object sender, EventArgs e) { }

        private void BtnDados_Click(object sender, EventArgs e)
        {
            dgvGrd.DataSource = grdItems;
        }

        private void BtnHeader_Click(object sender, EventArgs e)
        {
            //  -----------------------------------------------------------------
            //  Dimensionamento do grid
            //  Pode ser automatico qdo tem datasource ( como é o caso) ou manual
            //      dgvGrd.AutoGenerateColumns = false;
            //  O comando abaixo é serve para dimensionamento manual 
            //      dgvGrd.ColumnCount = 4;
            //  -----------------------------------------------------------------

            //  A property abaixo tem que ser false caso contrario 
            //  os comandos de estilo são ignorados.         
            dgvGrd.EnableHeadersVisualStyles = false;

            //  Header colors e fontes          
            dgvGrd.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvGrd.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvGrd.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.SteelBlue;

            //  O fonte default vem do componente pai do grid, no caso o form
            dgvGrd.ColumnHeadersDefaultCellStyle.Font = new Font(dgvGrd.Font.Name, dgvGrd.Font.Size + 1, FontStyle.Regular);

            //  Altura da linha de cabeçalho. Primeiro habilita resize e depois altera. 2.4 vezes a altura do fonte.
            dgvGrd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvGrd.ColumnHeadersHeight = Convert.ToInt16(2.4 * dgvGrd.ColumnHeadersDefaultCellStyle.Font.Height); ;

            //  Define o estilo da linha divisoria entre os headers
            dgvGrd.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
        }

        private void BtnRows_Click(object sender, EventArgs e)
        {
            //  Cor de fundo, fonte e cor da fonte
            dgvGrd.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvGrd.DefaultCellStyle.Font = new Font(dgvGrd.Font.Name, dgvGrd.Font.Size - 2, FontStyle.Regular);
            dgvGrd.DefaultCellStyle.ForeColor = Color.DarkSlateGray;

            //  Linhas alternadas de cores diferentes para facilitar a leitura
            dgvGrd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            //  Altura das linhas de texto. 1.8 vezes a altura do fonte
            dgvGrd.RowTemplate.Height = Convert.ToInt16(1.8 * dgvGrd.DefaultCellStyle.Font.Height);

            //  Row Headers são celulas vazias a esquerda de cada linha. Como no excel onde fica a numeracao
            dgvGrd.RowHeadersVisible = true;
            dgvGrd.RowHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;

            //  Fazendo altura = largura por estética apenas. Nao é necessário.
            dgvGrd.RowHeadersWidth = dgvGrd.RowTemplate.Height;

            ////  Zera o grid e carrega os dados de novo para alterar a altura das linhas.
            //dgvGrd.DataSource = null;
            //dgvGrd.DataSource = grdItems;
        }

        private void BtnCols_Click(object sender, EventArgs e)
        {
            FormatacaoColunas();
        }

        private void BtnBehavior_Click(object sender, EventArgs e)
        {
            //  Tira o rowheader
            dgvGrd.RowHeadersVisible = false;

            //  Muda seleção de linhas para apenas uma de cada vez
            dgvGrd.MultiSelect = false;

            //  Limpa qquer seleção  anterior
            dgvGrd.ClearSelection();

            //  Protege o grid de modificações
            //  --------------------------------------------
            //  Protege o grid todo
            //          dgvGrd.ReadOnly = true;

            //  Protege apenas uma coluna
            dgvGrd.Columns[0].ReadOnly = true;

            //  Protege apenas uma celula.
            //          dgvGrd.Rows[0].Cells[0].ReadOnly = true;

            //  Impede que o usuario mude (com o mouse) a altura de linha
            dgvGrd.AllowUserToResizeRows = false;

            //  Impede que o usuario mude a largura de uma coluna
            dgvGrd.AllowUserToResizeColumns = false;

            //  Permite que o usuario mude as colunas de lugar
            dgvGrd.AllowUserToOrderColumns = true;
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            //  -------------------------------------------------
            //  Configura Context Menu associado ao dgvGrd Grid
            //  --------------------------------------------------

            //  Abre um menu de contexto e associa ao grid
            ContextMenuStrip cmsDgvGrd = new ContextMenuStrip();
            dgvGrd.ContextMenuStrip = cmsDgvGrd;

            #region ContextMenu
            cmsDgvGrd.Items.Clear();
            //  Load menu strip options
            cmsDgvGrd.Items.Add(new ToolStripMenuItem
            {
                Font = new System.Drawing.Font("Segoe UI", 12F),
                BackColor = Color.DarkGray,
                ForeColor = Color.Snow,
                Text = "    Grid Options",
                Alignment = ToolStripItemAlignment.Right,
                Height = 2 * Height,
            });
            cmsDgvGrd.Items.Add(new ToolStripSeparator
            {
                BackColor = Color.Bisque,
                Height = 3
            });
            cmsDgvGrd.Items.Add(new ToolStripMenuItem
            {
                Font = new System.Drawing.Font("Segoe UI", 10F),
                ForeColor = Color.Black,
                Text = "Add New Row",
                Image = Properties.Resources.page
            });
            cmsDgvGrd.Items.Add(new ToolStripMenuItem
            {
                Font = new System.Drawing.Font("Segoe UI", 10F),
                ForeColor = Color.Black,
                Text = "Edit Selected Row",
                Image = Properties.Resources.New
            });
            cmsDgvGrd.Items.Add(new ToolStripMenuItem
            {
                Font = new System.Drawing.Font("Segoe UI", 10F),
                ForeColor = Color.Black,
                Text = "Delete Selected Row",
                Image = Properties.Resources.Delete4
            });
            cmsDgvGrd.Items.Add(new ToolStripSeparator
            {
                BackColor = Color.Bisque,
                Height = 3
            }); 
            cmsDgvGrd.Items.Add(new ToolStripMenuItem
            {   //  Vc tambem pode identificar cada item de menu por um nome
                Name = "tspUpdMktData",
                Font = new System.Drawing.Font("Segoe UI", 10F),
                ForeColor = Color.Black,
                Text = "Sort Rows Ascending",
                Image = Properties.Resources.SaveDisk
            });
            cmsDgvGrd.Items.Add(new ToolStripMenuItem
            {   //  Vc tambem pode identificar cada item de menu por um nome
                Name = "tspUpdMktData",
                Font = new System.Drawing.Font("Segoe UI", 10F),
                ForeColor = Color.Black,
                Text = "Sort Rows Descending",
                Image = Properties.Resources.search_red
            }); ;
            //  Add pointer to Click event handler
            cmsDgvGrd.ItemClicked += CmsDgvGrd_Click;
            #endregion
        }

        private void DgvGrd_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvGrd.ClearSelection();
                dgvGrd.Rows[e.RowIndex].Selected = true;

                if (e.RowIndex < dgvGrd.RowCount - 1)
                {
                    ClickPoint = dgvGrd.PointToScreen(
                                    dgvGrd.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex + 1, false).Location);
                }
                else
                {
                    ClickPoint = dgvGrd.PointToScreen(
                                    dgvGrd.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
                }
            }
        }

        private void CmsDgvGrd_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                switch (e.ClickedItem.Text)
                {
                case "Add New Row":
                    try
                    {
                        //  Instantiates new trade class and pass it on
                        GrdItem newGrd = new GrdItem();
                        using ( FrmEntry FrmEntry = new FrmEntry( "Save", ref newGrd) )
                        {
                            FrmEntry.StartPosition = FormStartPosition.Manual;
                            FrmEntry.Location = ClickPoint;
                            //  Show order pad                        
                            FrmEntry.ShowDialog();
                            //  Get order pad action performed
                            if ( FrmEntry.DialogResult == DialogResult.OK)
                            {
                                int selectedLine = dgvGrd.SelectedRows[0].Index;
                                grdItems.Insert( selectedLine, newGrd);
                                //  Force refresh
                                dgvGrd.DataSource = null;
                                dgvGrd.DataSource = grdItems;

                                //  For some reason grid looses format after refresh                
                                FormatacaoColunas();
                                //  Select the just added row
                                dgvGrd.Rows[ selectedLine].Selected = true;
                            }
                        };
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    break;
                case "Edit Selected Row":
                    if (dgvGrd.SelectedRows.Count > 0)
                    {
                        GrdItem editGrd = grdItems[ dgvGrd.SelectedRows[0].Index];
                        using (FrmEntry FrmEntry = new FrmEntry( "Update", ref editGrd))
                        {
                            FrmEntry.StartPosition = FormStartPosition.Manual;
                            FrmEntry.Location = ClickPoint;
                            //  Show order pad
                            FrmEntry.ShowDialog();
                            //  Get order pad action performed
                            if (FrmEntry.DialogResult == DialogResult.OK)
                            {
                                grdItems[dgvGrd.SelectedRows[0].Index] = editGrd;
                                dgvGrd.Refresh();
                            }
                        }
                    }
                    else
                    {
                        //SendMsg(" Please, right click the row you want to edit");
                    }
                    break;
                case "Delete Selected Row":
                    if ( dgvGrd.SelectedRows.Count > 0)
                    {
                        GrdItem deleteGrd = grdItems[dgvGrd.SelectedRows[0].Index];
                        using ( FrmEntry FrmEntry = new FrmEntry( "Delete", ref deleteGrd))
                        {
                            FrmEntry.StartPosition = FormStartPosition.Manual;
                            FrmEntry.Location = ClickPoint;
                            //  Show order pad
                            FrmEntry.ShowDialog();
                            //  Get order pad action performed
                            if (FrmEntry.DialogResult == DialogResult.OK)
                            {
                                grdItems.RemoveAt(dgvGrd.SelectedRows[0].Index);
                                //  Force refresh
                                dgvGrd.DataSource = null;
                                dgvGrd.DataSource = grdItems;

                                //  For some reason grid looses format after refresh                
                                FormatacaoColunas();
                            }
                        }
                    }
                    else
                    {
                        //SendMsg(" Please, right click the row you want to DELETE");
                    }
                    break;
                case "Sort Rows Ascending":
                    grdItems.Sort(( x, y) => x.Nome.CompareTo(y.Nome));
                        dgvGrd.Refresh();
                    break;
                case "Sort Rows Descending":
                    grdItems.Sort((x, y) => y.Nome.CompareTo(x.Nome));
                    dgvGrd.Refresh();
                    break;
                 default:
                    //SendMsg(e.ClickedItem.Text);
                    break;
            }
            }
            catch 
            {
                //SendMsg("Context menu : " + ex.Message);
            }                     
        }

        private void FormatacaoColunas()
        {
            //  Estes dois comandos sao necessarios quando a datasource vem de um banco de dados
            //  Tipo dataset, datatable etc. Nome das colunas nas tables e nome da coluna para ref.
            //          dgvGrd.Columns[0].Name = "Asset";
            //          dgvGrd.Columns[0].DataPropertyName = "IdAsset";
            //  -----------------------------------------------------------------------------------

            //  O texto no header de cada coluna pode vir do datasource mas pode ser modificado aqui
            dgvGrd.Columns[0].HeaderText = "Name";
            dgvGrd.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //  O posicionamento do texto = vertical (bottom, middle top) e horizontal(left, center, right)
            dgvGrd.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //  Auto size em fill estende a coluna ate que ocupe todo o espaco disponivel no grid
            dgvGrd.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //  Coluna  2   -   Numero de telefone
            dgvGrd.Columns[1].HeaderText = "Phone";
            dgvGrd.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrd.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //  Coluna  3   -   Nome do Departamento
            dgvGrd.Columns[2].HeaderText = "Depmto";
            dgvGrd.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrd.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //  Coluna  4   -   Data
            dgvGrd.Columns[3].HeaderText = "Period";
            dgvGrd.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrd.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //  Dimensiona a largura da coluna pelo maior conteudo entre as cels da coluna
            dgvGrd.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //  Formata Dia da semana, dia mes (extenso) e ano
            //  A documentacao do format pode ser encontrada no site Microsoft
            //  https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings

            //  Exemplo de regionaizacao
            CultureInfo Ci = new System.Globalization.CultureInfo(CultureInfo.CurrentCulture.Name);
            dgvGrd.Columns[3].DefaultCellStyle.Format = "ddd, dd/MM/yyyy";
            dgvGrd.Columns[3].DefaultCellStyle.FormatProvider = Ci;

            //  Coluna  5   -   Valor
            dgvGrd.Columns[4].HeaderText = "Salary";
            dgvGrd.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrd.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //  Formato de numero com 2 casas decimais
            dgvGrd.Columns[4].DefaultCellStyle.Format = "N2";   // 9.999,99

            //  Bordas das celulas do grid. No caso selecionamos apenas linhas horizontais
            dgvGrd.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvGrd.GridColor = Color.BurlyWood;     // Cor das linhas

            //  Cor da parte do grid nao preenchida pela lista igual a das linhas
            dgvGrd.BackgroundColor = dgvGrd.DefaultCellStyle.BackColor;

            //  Seleção de linhas - Marca a linha toda
            dgvGrd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //  Seleciona uma ou mais linhas ( control + click )
            dgvGrd.MultiSelect = false;
            //  Cor da linha selecionada
            dgvGrd.DefaultCellStyle.SelectionBackColor = Color.DarkGray;
            //  Limpa a selecao na apresentacao do grid
            dgvGrd.ClearSelection();
        }
    }
}