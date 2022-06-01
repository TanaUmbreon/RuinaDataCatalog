using System.Reactive.Disposables;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using RuinaDataCatalog.Core.Models;
using RuinaDataCatalog.Core.Repositories;

namespace RuinaDataCatalog.Wpf.ViewModels;

/// <summary>
/// バトル ページ部分 View をモデル化します。
/// </summary>
public class BattlePageViewModel : BindableBase, IDestructible
{
    /// <summary>インスタンス メンバーの Dispose 呼び出しを一括で行うためのコンポーネント</summary>
    private readonly CompositeDisposable _disposables = new();
    /// <summary>バトルページ XML 情報を参照するためのリポジトリ</summary>
    private readonly ICatalogCardRepository _repository;

    #region データ バインディング用プロパティ

    /// <summary>
    /// 表示中のバトル ページ情報のコレクションを取得します。
    /// </summary>
    public ReactiveCollection<CardInfo> DisplayedCards { get; }

    #endregion

    #region コマンド用プロパティ

    /// <summary>
    /// バトル ページ情報を表示させるコマンドを取得します。
    /// </summary>
    public AsyncReactiveCommand ShowCardsAsyncCommand { get; }

    #endregion

    /// <summary>
    /// <see cref="BattlePageViewModel"/> の新しいインスタンスを生成します。
    /// </summary>
    /// <param name="repository">DI コンテナによりインジェクションされた ICardXmlRepository。</param>
    public BattlePageViewModel(ICatalogCardRepository repository)
    {
        _repository = repository;

        DisplayedCards = new ReactiveCollection<CardInfo>()
            .AddTo(_disposables);

        ShowCardsAsyncCommand = new AsyncReactiveCommand();
        ShowCardsAsyncCommand.Subscribe(ShowCardsAsync)
            .AddTo(_disposables);
    }

    public void Destroy()
        => _disposables.Dispose();

    private Task ShowCardsAsync()
    {
        return Task.Run(() => DisplayedCards.AddRangeOnScheduler(_repository.GetCards()));
    }
}
