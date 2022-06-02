using System.Reactive.Disposables;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using RuinaDataCatalog.Core.Models;
using RuinaDataCatalog.Core.Repositories;

namespace RuinaDataCatalog.Wpf.ViewModels;

/// <summary>
/// バトル ページ情報を表示するリストをモデル化します。
/// </summary>
public class BattlePageListViewModel : BindableBase, IDestructible
{
    /// <summary>インスタンス メンバーの Dispose 呼び出しを一括で行うためのコンポーネント</summary>
    private readonly CompositeDisposable _disposables = new();
    /// <summary>バトルページ XML 情報を参照するためのリポジトリ</summary>
    private readonly ICatalogCardRepository _repository;

    #region データ バインディング用プロパティ

    /// <summary>
    /// 表示中のバトル ページ情報のコレクションを取得します。
    /// </summary>
    public ReactiveCollection<CardInfo> Cards { get; }

    #endregion

    #region コマンド用プロパティ

    /// <summary>
    /// バトル ページ情報の表示を消去するコマンドを取得します。
    /// </summary>
    public AsyncReactiveCommand ClearCardsAsyncCommand { get; }

    /// <summary>
    /// バトル ページ情報を表示させるコマンドを取得します。
    /// </summary>
    public AsyncReactiveCommand ShowCardsAsyncCommand { get; }

    #endregion

    /// <summary>
    /// <see cref="BattlePageListViewModel"/> の新しいインスタンスを生成します。
    /// </summary>
    /// <param name="repository">DI コンテナによりインジェクションされた ICardXmlRepository。</param>
    public BattlePageListViewModel(ICatalogCardRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        Cards = new ReactiveCollection<CardInfo>()
            .AddTo(_disposables);

        ClearCardsAsyncCommand = new AsyncReactiveCommand();
        ClearCardsAsyncCommand.Subscribe(ClearCardsAsync)
            .AddTo(_disposables);

        ShowCardsAsyncCommand = new AsyncReactiveCommand();
        ShowCardsAsyncCommand.Subscribe(ShowCardsAsync)
            .AddTo(_disposables);
    }

    public void Destroy()
        => _disposables.Dispose();

    private Task ClearCardsAsync()
    {
        return Task.Run(() => {
            Cards.ClearOnScheduler();
        });
    }

    private Task ShowCardsAsync()
    {
        return Task.Run(() => {
            Cards.AddRangeOnScheduler(_repository.GetCards());
        });
    }
}
