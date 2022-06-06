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

    private bool _isCheckedChapter1;
    private bool _isCheckedChapter2;
    private bool _isCheckedChapter3;
    private bool _isCheckedChapter4;
    private bool _isCheckedChapter5;
    private bool _isCheckedChapter6;
    private bool _isCheckedChapter7;

    #region データ バインディング用プロパティ

    public ReactivePropertySlim<bool> IsCheckedAll { get; }
    public ReactivePropertySlim<bool> IsCheckedChapter1 { get; }
    public ReactivePropertySlim<bool> IsCheckedChapter2 { get; }
    public ReactivePropertySlim<bool> IsCheckedChapter3 { get; }
    public ReactivePropertySlim<bool> IsCheckedChapter4 { get; }
    public ReactivePropertySlim<bool> IsCheckedChapter5 { get; }
    public ReactivePropertySlim<bool> IsCheckedChapter6 { get; }
    public ReactivePropertySlim<bool> IsCheckedChapter7 { get; }

    #endregion

    #region コマンド用プロパティ

    public ReactiveCommand ToggleAllCommand { get; }
    public ReactiveCommand ToggleChapter1Command { get; }
    public ReactiveCommand ToggleChapter2Command { get; }
    public ReactiveCommand ToggleChapter3Command { get; }
    public ReactiveCommand ToggleChapter4Command { get; }
    public ReactiveCommand ToggleChapter5Command { get; }
    public ReactiveCommand ToggleChapter6Command { get; }
    public ReactiveCommand ToggleChapter7Command { get; }

    #endregion

    /// <summary>
    /// <see cref="BattlePageViewModel"/> の新しいインスタンスを生成します。
    /// </summary>
    public BattlePageViewModel()
    {
        IsCheckedAll = new ReactivePropertySlim<bool>(true).AddTo(_disposables);
        IsCheckedChapter1 = new ReactivePropertySlim<bool>(false).AddTo(_disposables);
        IsCheckedChapter2 = new ReactivePropertySlim<bool>(false).AddTo(_disposables);
        IsCheckedChapter3 = new ReactivePropertySlim<bool>(false).AddTo(_disposables);
        IsCheckedChapter4 = new ReactivePropertySlim<bool>(false).AddTo(_disposables);
        IsCheckedChapter5 = new ReactivePropertySlim<bool>(false).AddTo(_disposables);
        IsCheckedChapter6 = new ReactivePropertySlim<bool>(false).AddTo(_disposables);
        IsCheckedChapter7 = new ReactivePropertySlim<bool>(false).AddTo(_disposables);

        ToggleAllCommand = new ReactiveCommand();
        ToggleAllCommand.Subscribe(ToggleAll).AddTo(_disposables);
        ToggleChapter1Command = new ReactiveCommand();
        ToggleChapter1Command.Subscribe(ToggleChapter1).AddTo(_disposables);
        ToggleChapter2Command = new ReactiveCommand();
        ToggleChapter2Command.Subscribe(ToggleChapter2).AddTo(_disposables);
        ToggleChapter3Command = new ReactiveCommand();
        ToggleChapter3Command.Subscribe(ToggleChapter3).AddTo(_disposables);
        ToggleChapter4Command = new ReactiveCommand();
        ToggleChapter4Command.Subscribe(ToggleChapter4).AddTo(_disposables);
        ToggleChapter5Command = new ReactiveCommand();
        ToggleChapter5Command.Subscribe(ToggleChapter5).AddTo(_disposables);
        ToggleChapter6Command = new ReactiveCommand();
        ToggleChapter6Command.Subscribe(ToggleChapter6).AddTo(_disposables);
        ToggleChapter7Command = new ReactiveCommand();
        ToggleChapter7Command.Subscribe(ToggleChapter7).AddTo(_disposables);

        _isCheckedChapter1 = IsCheckedChapter1.Value;
        _isCheckedChapter2 = IsCheckedChapter2.Value;
        _isCheckedChapter3 = IsCheckedChapter3.Value;
        _isCheckedChapter4 = IsCheckedChapter4.Value;
        _isCheckedChapter5 = IsCheckedChapter5.Value;
        _isCheckedChapter6 = IsCheckedChapter6.Value;
        _isCheckedChapter7 = IsCheckedChapter7.Value;
    }

    public void Destroy()
        => _disposables.Dispose();

    private void ToggleAll()
    {
        if (IsCheckedAll.Value) { return; }
        IsCheckedAll.Value = !IsCheckedAll.Value;
        IsCheckedChapter1.Value = IsCheckedAll.Value ? false : _isCheckedChapter1;
        IsCheckedChapter2.Value = IsCheckedAll.Value ? false : _isCheckedChapter2;
        IsCheckedChapter3.Value = IsCheckedAll.Value ? false : _isCheckedChapter3;
        IsCheckedChapter4.Value = IsCheckedAll.Value ? false : _isCheckedChapter4;
        IsCheckedChapter5.Value = IsCheckedAll.Value ? false : _isCheckedChapter5;
        IsCheckedChapter6.Value = IsCheckedAll.Value ? false : _isCheckedChapter6;
        IsCheckedChapter7.Value = IsCheckedAll.Value ? false : _isCheckedChapter7;
    }

    private void ToggleChapter1()
    {
        IsCheckedAll.Value = false;
        IsCheckedChapter1.Value = !IsCheckedChapter1.Value;
        _isCheckedChapter1 = IsCheckedChapter1.Value;
    }

    private void ToggleChapter2()
    {
        IsCheckedAll.Value = false;
        IsCheckedChapter2.Value = !IsCheckedChapter2.Value;
        _isCheckedChapter2 = IsCheckedChapter2.Value;
    }

    private void ToggleChapter3()
    {

    }

    private void ToggleChapter4()
    {

    }

    private void ToggleChapter5()
    {

    }

    private void ToggleChapter6()
    {

    }

    private void ToggleChapter7()
    {

    }
}
