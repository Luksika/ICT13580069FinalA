using System;
using System.Collections.Generic;
using ICT13580069FinalA.Models;
using Xamarin.Forms;

namespace ICT13580069FinalA
{
    public partial class MainNewPage : ContentPage
    {
        public MainNewPage()
        {
            InitializeComponent();

            saveButton.Clicked += SaveButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;

            categoryPicker.Items.Add("หญิง");
            categoryPicker.Items.Add("ชาย");
        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOK = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึก", "ใช่", "ไม่ใช่");
            if (isOK)
            {
                var product = new Product();
                product.Name = nameEntry.Text;
                product.Description = descriptionEditor.Text;
                product.Category = categoryPicker.SelectedItem.ToString();
                product.ProductPrice = decimal.Parse(productPriceEntry.Text);
                product.SellPrice = decimal.Parse(sellPriceEntry.Text);
                product.Stock = int.Parse(stockEntry.Text);

                var id = App.DbHelper.AddProduct(product);
                await DisplayAlert("บันทึกสำเร็จ", "ชื่อของท่าน" + id, "ตกลง");
                await Navigation.PopModalAsync();
            }
        }

        void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
