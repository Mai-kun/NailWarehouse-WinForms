namespace NailWarehouse.Forms
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            numSize = new NumericUpDown();
            numMinimumQuantity = new NumericUpDown();
            numQuantity = new NumericUpDown();
            btnDone = new Button();
            cbMaterials = new ComboBox();
            tbName = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            numPrice = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMinimumQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();
            // 
            // numSize
            // 
            numSize.DecimalPlaces = 2;
            numSize.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numSize.Location = new Point(235, 69);
            numSize.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            numSize.Name = "numSize";
            numSize.Size = new Size(161, 23);
            numSize.TabIndex = 26;
            // 
            // numMinimumQuantity
            // 
            numMinimumQuantity.Location = new Point(235, 172);
            numMinimumQuantity.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            numMinimumQuantity.Name = "numMinimumQuantity";
            numMinimumQuantity.Size = new Size(161, 23);
            numMinimumQuantity.TabIndex = 25;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(235, 141);
            numQuantity.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(161, 23);
            numQuantity.TabIndex = 24;
            // 
            // btnDone
            // 
            btnDone.Location = new Point(172, 263);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(98, 38);
            btnDone.TabIndex = 23;
            btnDone.Text = "Готово";
            btnDone.UseVisualStyleBackColor = true;
            btnDone.Click += btnDone_Click;
            // 
            // cbMaterials
            // 
            cbMaterials.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaterials.FormattingEnabled = true;
            cbMaterials.Location = new Point(235, 104);
            cbMaterials.Name = "cbMaterials";
            cbMaterials.Size = new Size(161, 23);
            cbMaterials.TabIndex = 22;
            // 
            // tbName
            // 
            tbName.Location = new Point(235, 34);
            tbName.Name = "tbName";
            tbName.Size = new Size(161, 23);
            tbName.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 209);
            label6.Name = "label6";
            label6.Size = new Size(92, 15);
            label6.TabIndex = 19;
            label6.Text = "Цена (без НДС)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 174);
            label5.Name = "label5";
            label5.Size = new Size(172, 15);
            label5.TabIndex = 18;
            label5.Text = "Минимальный предел кол-ва";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 141);
            label4.Name = "label4";
            label4.Size = new Size(128, 15);
            label4.TabIndex = 17;
            label4.Text = "Количество на складе";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 107);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 16;
            label3.Text = "Материал ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 71);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 15;
            label2.Text = "Размер";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 37);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 14;
            label1.Text = "Наименование";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(235, 207);
            numPrice.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(161, 23);
            numPrice.TabIndex = 27;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 338);
            Controls.Add(numPrice);
            Controls.Add(numSize);
            Controls.Add(numMinimumQuantity);
            Controls.Add(numQuantity);
            Controls.Add(btnDone);
            Controls.Add(cbMaterials);
            Controls.Add(tbName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditForm";
            Text = "Изменение данных продукта";
            ((System.ComponentModel.ISupportInitialize)numSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMinimumQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numSize;
        private NumericUpDown numMinimumQuantity;
        private NumericUpDown numQuantity;
        private Button btnDone;
        private ComboBox cbMaterials;
        private TextBox tbName;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ErrorProvider errorProvider1;
        private NumericUpDown numPrice;
    }
}