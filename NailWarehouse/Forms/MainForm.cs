using NailWarehouse.Contracts;
using NailWarehouse.Contracts.Models;
using NailWarehouse.Forms;

namespace NailWarehouse
{
    public partial class MainForm : Form
    {
        private IProductManager productManager;
        private readonly BindingSource bindingSource;

        public MainForm(IProductManager manager)
        {
            InitializeComponent();

            productManager = manager;
            bindingSource = new BindingSource();

            dataGridView1.DataSource = bindingSource;
        }

        private async void TSBAdd_Click(object sender, EventArgs e)
        {
            using var editForm = new ProductForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await productManager.AddAsync(editForm.Product);
                bindingSource.ResetBindings(false);
                await UpdateStatusStrip();
            }
        }

        private async void TSBDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var oldProduct = (Product)dataGridView1.CurrentRow.DataBoundItem;

                if (MessageBox.Show(
                    $"Вы хотите удалить товар \"{oldProduct.Name}\"?",
                    "Внимание",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                    ) == DialogResult.OK)
                {
                    await productManager.DeleteAsync(oldProduct.Id);
                    bindingSource.ResetBindings(false);
                    await UpdateStatusStrip();
                }
            }
        }

        private async void TSBChange_ClickAsync(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var oldProduct = (Product)dataGridView1.CurrentRow.DataBoundItem;

                using var editForm = new ProductForm(oldProduct);

                if (MessageBox.Show(
                    $"Вы хотите изменить товар \"{oldProduct.Name}\"?",
                    "Внимание",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information
                    ) == DialogResult.OK)
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        await productManager.EditAsync(editForm.Product);
                        bindingSource.ResetBindings(false);
                        await UpdateStatusStrip();
                    }
                }
            }
        }

        private async Task UpdateStatusStrip()
        {
            var result = await productManager.GetStatsAsync();
            tssRowsAmount.Text = $"Количество товаров: {result.TotalAmount}";
            tssPriceNDS.Text = $"Цена с НДС: {result.FullPriceWithNds}";
            tssPriceNoNDS.Text = $"Цена без НДС: {result.FullPriceNoNds}";
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "TotalPrice")
            {
                var row = (Product)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                e.Value = row.Quantity * row.Price;
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = await productManager.GetAllAsync();
            await UpdateStatusStrip();
            dataGridView1.Columns.Add("TotalPrice", "Общая цена");
            dataGridView1.Columns[nameof(Product.Id)].Visible = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
