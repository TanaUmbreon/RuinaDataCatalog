using System.Windows;
using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using RuinaDataCatalog.Core.Infrastructures;
using RuinaDataCatalog.Core.Repositories;
using RuinaDataCatalog.Wpf.Views;

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

        // DIコンテナに使用するインターフェイスとその実装型を登録する
        //containerRegistry.RegisterSingleton<ICardXmlRepository, CardXmlRepository>();

        // DIコンテナ実装ライブラリ(DryIoc)固有の機能を使用して型を登録する
        // (IContainerRegistryではデフォルトコンストラクタのクラスしか登録できないのでそれを解消するため)
        IContainer container = containerRegistry.GetContainer();
        container.Register<ICatalogCardRepository, SqliteCatalogCardRepository>(Reuse.Singleton, Made.Of(
            () => new SqliteCatalogCardRepository("Ruina.db")));
    }
}
