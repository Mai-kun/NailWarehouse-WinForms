using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Forms
{
    public partial class EditForm : Form
    {
        private Product editedProduct;
        public Product EditedProduct => editedProduct;

        public EditForm(Product? oldProduct = null)
        {
            InitializeComponent();
            InitializeComboBox();

            editedProduct = oldProduct ?? DataGenerator.CreateDefaultProduct();

            tbName.AddBinding(control => control.Text, editedProduct, product => product.Name, errorProvider1);
            numSize.AddBinding(control => control.Value, editedProduct, product => product.Size, errorProvider1);
            cbMaterials.AddBinding(control => control.SelectedItem, editedProduct, product => product.Material, errorProvider1);
            numQuantity.AddBinding(control => control.Value, editedProduct, product => product.Quantity, errorProvider1);
            numMinimumQuantity.AddBinding(control => control.Value, editedProduct, product => product.MinimumQuantity, errorProvider1);
            numPrice.AddBinding(control => control.Value, editedProduct, product => product.Price, errorProvider1);
        }

        private void InitializeComboBox()
        {
            cbMaterials.DataSource = EnumHelper.GetEnumDescriptions(typeof(Materials));
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            foreach (Control c in errorProvider1.ContainerControl.Controls)
            {
                if (errorProvider1.GetError(c) != "")
                {
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
