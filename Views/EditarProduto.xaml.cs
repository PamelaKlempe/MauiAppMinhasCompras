using MauiAppMinhasCompras.Models;
using MauiAppMinhasCompras.Helpers;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
    SQLiteDatabaseHelper db;

    public EditarProduto(SQLiteDatabaseHelper databaseHelper)
    {
        InitializeComponent();
        db = databaseHelper;
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto p = BindingContext as Produto;

            p.Descricao = txt_descricao.Text;
            p.Quantidade = Convert.ToDouble(txt_quantidade.Text);
            p.Preco = Convert.ToDouble(txt_preco.Text);

            await db.Update(p);

            await DisplayAlert("Sucesso", "Produto atualizado!", "OK");

            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}