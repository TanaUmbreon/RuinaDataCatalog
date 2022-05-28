namespace RuinaDataCatalog.Core.Models;

/// <summary>
/// ローカライズされたバトル ページ説明の情報を格納します。
/// </summary>
public class CardDescriptionInfo
{
    /// <summary>
    /// バトル ページ説明の ID を取得または設定します。
    /// </summary>
    public int Id { get; set; } = 0;

    /// <summary>
    /// ローカライズされたバトル ページ名を取得または設定します。
    /// </summary>
    public string LocalizedName { get; set; } = "";

    /// <summary>
    /// ローカライズされたバトル ページ効果の説明を取得または設定します。
    /// </summary>
    public string Ability { get; set; } = "";

    /// <summary>
    /// ローカライズされたバトル ダイス効果の説明を取得または設定します。
    /// </summary>
    public IEnumerable<CardBehaviourDescriptionInfo> Behaviour { get; set; } = Array.Empty<CardBehaviourDescriptionInfo>();
}
