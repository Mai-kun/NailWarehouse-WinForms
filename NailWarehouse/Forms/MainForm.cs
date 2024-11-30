using NailWarehouse.Contracts;
using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Forms
{
    public partial class MainForm : Form
    {
        private readonly BindingSource bindingSource;
        private readonly IProductManager productManager;

        public MainForm(IProductManager manager)
        {
            InitializeComponent();

            productManager = manager;
            bindingSource = new BindingSource();

            dataGridView1.DataSource = bindingSource;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await Task.WhenAll(LoadProducts(), UpdateStatusStrip());
            dataGridView1.Columns.Add("TotalPrice", "Общая цена");
            dataGridView1.Columns[nameof(Product.Id)].Visible = false;
        }

        private async Task LoadProducts()
        {
            bindingSource.DataSource = await productManager.GetAllAsync();
            bindingSource.ResetBindings(false);
        }

        private async void TSBAdd_Click(object sender, EventArgs e)
        {
            using var productForm = new ProductForm();
            if (productForm.ShowDialog() == DialogResult.OK)
            {
                await productManager.AddAsync(productForm.Product);
                await Task.WhenAny(LoadProducts(), UpdateStatusStrip());
            }
        }

        private async void TSBDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            var oldProduct = (Product)dataGridView1.CurrentRow.DataBoundItem;

            if (MessageBox.Show(
                    $"Вы хотите удалить товар \"{oldProduct.Name}\"?",
                    "Внимание",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                ) == DialogResult.OK)
            {
                await productManager.DeleteAsync(oldProduct.Id);
                await Task.WhenAny(LoadProducts(), UpdateStatusStrip());
            }
        }

        private async void TSBChange_ClickAsync(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            var oldProduct = dataGridView1.CurrentRow.DataBoundItem as Product;
            if (MessageBox.Show(
                    $"Вы хотите изменить товар \"{oldProduct?.Name}\"?",
                    "Внимание",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information
                ) != DialogResult.OK)
            {
                return;
            }

            using var editForm = new ProductForm(oldProduct);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await productManager.EditAsync(editForm.Product);
                await Task.WhenAny(LoadProducts(), UpdateStatusStrip());
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
                var row = dataGridView1.Rows[e.RowIndex].DataBoundItem as Product;
                e.Value = row?.Quantity * row?.Price;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
            => Close();
    }
}
