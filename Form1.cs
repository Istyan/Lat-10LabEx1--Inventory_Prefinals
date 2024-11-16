using System.Text.RegularExpressions;

namespace Inventory
{
    public partial class frmAddProduct : Form
    {
        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;
        private int _Quantity;
        private double _SellPrice;

        private BindingSource showProductList;

        public frmAddProduct()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }

        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$")) // Allows spaces in product name
                throw new ArgumentException("Invalid product name. Only alphabetic characters are allowed.");
            return name;
        }

        // Validation for Quantity
        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^\d+$")) // Ensures only digits are accepted
                throw new ArgumentException("Invalid quantity. Only numeric values are allowed.");
            return Convert.ToInt32(qty);
        }

        // Validation for Selling Price
        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price, @"^(\d+(\.\d{1,2})?)$")) // Allows up to two decimal places
                throw new ArgumentException("Invalid selling price. Please enter a valid number.");
            return Convert.ToDouble(price);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new string[]
       {
            "Beverages",
            "Bread/Bakery",
            "Canned/Jarred Goods",
            "Dairy",
            "Frozen Goods",
            "Meat",
            "Personal Care",
            "Other"
       };
            foreach (string category in ListOfProductCategory)
            {
                cbCategory.Items.Add(category);
            }

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            _ProductName = Product_Name(txtProductName.Text);
            _Category = cbCategory.Text;
            _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
            _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
            _Description = richTxtDescription.Text;
            _Quantity = Quantity(txtQuantity.Text);
            _SellPrice = SellingPrice(txtSellPrice.Text);
            showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
            _ExpDate, _SellPrice, _Quantity, _Description));
            gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridViewProductList.DataSource = showProductList;
        }
    }
}
