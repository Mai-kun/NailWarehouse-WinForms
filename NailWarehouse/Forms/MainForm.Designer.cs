
namespace NailWarehouse
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            правкаToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            tssRowsAmount = new ToolStripStatusLabel();
            tssPriceNDS = new ToolStripStatusLabel();
            tssPriceNoNDS = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            TSBAdd = new ToolStripButton();
            TSBDelete = new ToolStripButton();
            TSBChange = new ToolStripButton();
            dataGridView1 = new DataGridView();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, правкаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(109, 22);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // правкаToolStripMenuItem
            // 
            правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            правкаToolStripMenuItem.Size = new Size(65, 20);
            правкаToolStripMenuItem.Text = "Справка";
            // 
            // statusStrip1
            // 
            statusStrip1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tssRowsAmount, tssPriceNDS, tssPriceNoNDS });
            statusStrip1.Location = new Point(0, 415);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 35);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // tssRowsAmount
            // 
            tssRowsAmount.Name = "tssRowsAmount";
            tssRowsAmount.Size = new Size(231, 30);
            tssRowsAmount.Text = "Количество товаров: 0";
            // 
            // tssPriceNDS
            // 
            tssPriceNDS.Margin = new Padding(30, 3, 0, 2);
            tssPriceNDS.Name = "tssPriceNDS";
            tssPriceNDS.Size = new Size(150, 30);
            tssPriceNDS.Text = "Цена с НДС: 0";
            // 
            // tssPriceNoNDS
            // 
            tssPriceNoNDS.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tssPriceNoNDS.Margin = new Padding(30, 3, 0, 2);
            tssPriceNoNDS.Name = "tssPriceNoNDS";
            tssPriceNoNDS.Size = new Size(172, 30);
            tssPriceNoNDS.Text = "Цена без НДС: 0";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(23, 23);
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip1.GripMargin = new Padding(5);
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { TSBAdd, TSBDelete, TSBChange });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0);
            toolStrip1.Size = new Size(800, 27);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // TSBAdd
            // 
            TSBAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TSBAdd.Image = Properties.Resources.plus;
            TSBAdd.ImageTransparentColor = Color.Magenta;
            TSBAdd.Name = "TSBAdd";
            TSBAdd.Size = new Size(24, 24);
            TSBAdd.Text = "Добавить";
            TSBAdd.Click += TSBAdd_Click;
            // 
            // TSBDelete
            // 
            TSBDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TSBDelete.Image = Properties.Resources.cross;
            TSBDelete.ImageTransparentColor = Color.Magenta;
            TSBDelete.Name = "TSBDelete";
            TSBDelete.Size = new Size(24, 24);
            TSBDelete.Text = "Удалить";
            TSBDelete.Click += TSBDelete_Click;
            // 
            // TSBChange
            // 
            TSBChange.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TSBChange.Image = Properties.Resources.pencil;
            TSBChange.ImageTransparentColor = Color.Magenta;
            TSBChange.Name = "TSBChange";
            TSBChange.Size = new Size(24, 24);
            TSBChange.Text = "Изменить";
            TSBChange.Click += TSBChange_ClickAsync;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 51);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(800, 364);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(680, 400);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главная форма";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem правкаToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStrip toolStrip1;
        private ToolStripButton TSBAdd;
        private ToolStripButton TSBDelete;
        private ToolStripButton TSBChange;
        private DataGridView dataGridView1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripStatusLabel tssRowsAmount;
        private ToolStripStatusLabel tssPriceNDS;
        private ToolStripStatusLabel tssPriceNoNDS;
    }
}
