using System.Reactive.Disposables;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace RuinaDataCatalog.Wpf.ViewModels.ContentPages;

/// <summary>
/// バトル ページ部分 View をモデル化します。
/// </summary>
public class BattlePageViewModel : BindableBase, IDestructible
{
    /// <summary>インスタンス メンバーの Dispose 呼び出しを一括で行うためのコンポーネント</summary>
    private readonly CompositeDisposable _disposables = new();

    /// <summary>
    /// <see cref="BattlePageViewModel"/> の新しいインスタンスを生成します。
    /// </summary>
    public BattlePageViewModel() { }

    public void Destroy()
        => _disposables.Dispose();
}
