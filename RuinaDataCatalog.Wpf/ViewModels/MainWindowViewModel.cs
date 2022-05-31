using System.Reactive.Disposables;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using RuinaDataCatalog.Wpf.CommandArgs;

namespace RuinaDataCatalog.Wpf.ViewModels;

/// <summary>
/// メイン ウィンドウをモデル化します。
/// </summary>
public class MainWindowViewModel : BindableBase, IDisposable
{
    /// <summary>メイン コンテンツ Region の名前</summary>
    private const string ContentRegionName = "ContentRegion";

    /// <summary>Region に表示する部分 View を切り替えるための管理オブジェクト</summary>
    private readonly IRegionManager _regionManager;
    /// <summary>インスタンス メンバーの Dispose 呼び出しを一括で行うためのコンポーネント</summary>
    private readonly CompositeDisposable _disposables = new();

    #region データ バインディング用プロパティ

    /// <summary>
    /// ウィンドウ タイトルを取得します。
    /// </summary>
    public ReactivePropertySlim<string> Title { get; }

    /// <summary>
    /// 現在表示しているメニューの名前を取得します。
    /// </summary>
    public ReactivePropertySlim<string> CurrentMenuName { get; }

    #endregion

    #region コマンド用プロパティ

    /// <summary>
    /// メイン コンテンツ Region に表示する部分 View を切り替えるコマンドを取得します。
    /// </summary>
    public DelegateCommand<NavigateCommandArgs> NavigateCommand { get; }

    #endregion

    /// <summary>
    /// <see cref="MainWindowViewModel"/> の新しいインスタンスを生成します。
    /// </summary>
    /// <param name="regionManager">DI コンテナによりインジェクションされた IRegionManager。</param>
    public MainWindowViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager ?? throw new ArgumentNullException(nameof(regionManager));

        // ReactiveProperty (Slim) は Subscribe メソッド等で値変更の監視をしている場合だと
        // Dispose を呼び出さないとメモリリークする可能性がある。
        // そのため Dispose が呼び出されるように CompositeDisposable へ登録
        Title = new ReactivePropertySlim<string>(AssemblyInfo.ProductName)
            .AddTo(_disposables);
        CurrentMenuName = new ReactivePropertySlim<string>("ABC")
            .AddTo(_disposables);

        NavigateCommand = new DelegateCommand<NavigateCommandArgs>(Navigate);
    }

    /// <summary>
    /// メイン コンテンツ Region に表示する部分 View を指定したコマンド引数に基づいて切り替えます。
    /// </summary>
    /// <param name="args">切り替え先となる部分 View の情報を格納したコマンド引数。</param>
    private void Navigate(NavigateCommandArgs args)
    {
        if (args == null) { throw new ArgumentNullException(nameof(args)); }

        _regionManager.RequestNavigate(ContentRegionName, args.NavigatePath);
        CurrentMenuName.Value = args.ViewTitle;
    }

    #region Dispose パターンの実装
   
    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // アプリで配置した部分 View の ViewModel を破棄 (IDestructible.Destroy を呼び出す)
                foreach (var region in _regionManager.Regions)
                {
                    region.RemoveAll();
                }

                _disposables.Dispose();
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
