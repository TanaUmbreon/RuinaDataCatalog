using System.Windows.Controls;
using RuinaDataCatalog.Wpf.ViewModels.Controls;

namespace RuinaDataCatalog.Wpf.Views.Controls;

/// <summary>
/// BattlePageItem.xaml の相互作用ロジック
/// </summary>
public partial class BattlePageListView : UserControl
{
    public BattlePageListView()
    {
        InitializeComponent();
    }

    private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        if (DataContext is not BattlePageListViewModel vm) { return; }

        await vm.ClearCardsAsyncCommand.ExecuteAsync();
        await vm.ShowCardsAsyncCommand.ExecuteAsync();
    }
}
