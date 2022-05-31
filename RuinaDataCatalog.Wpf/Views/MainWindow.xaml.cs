using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ModernWpf.Controls;
using RuinaDataCatalog.Wpf.CommandArgs;
using RuinaDataCatalog.Wpf.ViewModels;

namespace RuinaDataCatalog.Wpf.Views;

/// <summary>
/// LanguageWindow.xaml の相互作用ロジック
/// </summary>
public partial class MainWindow : Window
{
    private readonly MainWindowViewModel _viewModel;

    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // XAML側で選択しているメニュー項目に対応する画面を表示させる
        var selectedItem = NavigationView.MenuItems.OfType<NavigationViewItem>().FirstOrDefault(i => i.IsSelected);
        Navigate(selectedItem);
    }

    private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        // 選択されたメニュー項目に対応する画面を表示させる
        var invokedItem = args.InvokedItemContainer as NavigationViewItem;
        Navigate(invokedItem);
    }

    private void Navigate(NavigationViewItem? item)
    {
        if (item == null) { return; }
        if (item.Tag is not string path) { return; }

        string title = item.Content as string ?? "";
        _viewModel.NavigateCommand.Execute(new NavigateCommandArgs(path, title));
    }
}
