using System.ComponentModel.DataAnnotations;
using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Forms
{
    public partial class ProductForm : Form
    {
        private readonly Product product;

        public ProductForm(Product oldProduct = null)
        {
            InitializeComponent();
            InitializeComboBox();

            product = oldProduct ?? new Product()
            {
                Id = Guid.NewGuid(),
                Name = "",
                Material = EnumHelper.GetEnumDescription(Materials.Copper),
            };

            tbName.AddBinding(control => control.Text, product, product => product.Name, errorProvider1);
            numSize.AddBinding(control => control.Value, product, product => product.Size, errorProvider1);
            cbMaterials.AddBinding(control => control.SelectedItem, product, product => product.Material);
            numQuantity.AddBinding(control => control.Value, product, product => product.Quantity, errorProvider1);
            numMinimumQuantity.AddBinding(control => control.Value, product, product => product.MinimumQuantity, errorProvider1);
            numPrice.AddBinding(control => control.Value, product, product => product.Price, errorProvider1);
        }

        public Product Product => product;

        private void InitializeComboBox()
        {
            cbMaterials.DataSource = EnumHelper.GetEnumDescriptions(typeof(Materials));
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            var context = new ValidationContext(product);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(product, context, results, validateAllProperties: true))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
