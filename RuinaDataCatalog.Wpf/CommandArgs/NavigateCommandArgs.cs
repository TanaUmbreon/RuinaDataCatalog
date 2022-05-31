namespace RuinaDataCatalog.Wpf.CommandArgs;

/// <summary>
/// 
/// </summary>
/// <param name="NavigatePath">遷移先のビューを指定するパス。</param>
/// <param name="ViewTitle">遷移先のビューのタイトル。</param>
public record NavigateCommandArgs(string NavigatePath, string ViewTitle)
{
    /// <summary>
    /// 遷移先のビューを指定するパスを取得します。
    /// </summary>
    public string NavigatePath { get; init; } =
        NavigatePath ?? throw new ArgumentNullException(nameof(NavigatePath));

    /// <summary>
    /// 遷移先のビューのタイトルを取得します。
    /// </summary>
    public string ViewTitle { get; init; } =
        ViewTitle ?? throw new ArgumentNullException(nameof(ViewTitle));
}
