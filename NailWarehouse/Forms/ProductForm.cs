using System.ComponentModel.DataAnnotations;
using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Forms
{
    public partial class ProductForm : Form
    {
        public Product Product { get; }

        public ProductForm(Product? oldProduct = null)
        {
            InitializeComponent();
            InitializeComboBox();

            Product = oldProduct?.Clone() ?? new Product
            {
                Id = Guid.NewGuid(),
                Name = "",
                Size = 0,
                Material = EnumHelper.GetEnumDescription(Materials.Copper),
                Quantity = 0,
                MinimumQuantity = 0,
                Price = 0,
            };

            tbName.AddBinding(control => control.Text, Product, product => product.Name, errorProvider1);
            numSize.AddBinding(control => control.Value, Product, product => product.Size, errorProvider1);
            cbMaterials.AddBinding(control => control.SelectedItem, Product, product => product.Material);
            numQuantity.AddBinding(control => control.Value, Product, product => product.Quantity, errorProvider1);
            numMinimumQuantity.AddBinding(control => control.Value, Product, product => product.MinimumQuantity, errorProvider1);
            numPrice.AddBinding(control => control.Value, Product, product => product.Price, errorProvider1);
        }

        private void InitializeComboBox()
        {
            cbMaterials.DataSource = EnumHelper.GetEnumDescriptions(typeof(Materials));
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            var context = new ValidationContext(Product);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(Product, context, results, validateAllProperties: true))
            {
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
