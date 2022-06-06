using System.Windows;
using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using RuinaDataCatalog.Core.Infrastructures;
using RuinaDataCatalog.Core.Repositories;
using RuinaDataCatalog.Wpf.ViewModels.Controls;
using RuinaDataCatalog.Wpf.ViewModels.Windows;
using RuinaDataCatalog.Wpf.Views.ContentPages;
using RuinaDataCatalog.Wpf.Views.Windows;

namespace RuinaDataCatalog.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    protected override Window CreateShell()
        => Container.Resolve<MainWindow>();

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<BattlePageView>();
        containerRegistry.RegisterForNavigation<CorePageView>();
        containerRegistry.RegisterForNavigation<PassiveView>();

        // XAML側のViewModelLocator.AutoWireViewModelによる自動バインディングと、
        // コードビハインド側のコンストラクタDIで異なるインスタンスを注入されないようシングルトンにする
        // (これをやらないとXAML側とコードビハインド側でViewModelが異なるインスタンスとなって
        //  思わぬ不具合が生じてしまうのでそれを回避している)
        containerRegistry.RegisterSingleton<MainWindowViewModel>();
        containerRegistry.RegisterSingleton<BattlePageListViewModel>();

        // DIコンテナ実装ライブラリ(DryIoc)固有の機能を使用して、
        // DIコンテナで使用するインターフェイスとその実装クラスを登録する
        // (IContainerRegistryではデフォルトコンストラクタのクラスしか登録できないので、
        //  実装ライブラリ固有の拡張メソッドを使って解消している)
        IContainer container = containerRegistry.GetContainer();
        container.Register<ICatalogCardRepository, SqliteCatalogCardRepository>(Reuse.Singleton, Made.Of(
            () => new SqliteCatalogCardRepository("Ruina.db")));
    }
}
