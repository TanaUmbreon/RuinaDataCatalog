namespace RuinaDataCatalog.RuinaDBSetup.Models;

/// <summary>
/// ローカライズされたバトル ダイスの振る舞い説明の情報を格納します。
/// </summary>
public class CardBehaviourDescriptionInfo
{
    /// <summary>
    /// バトル ダイスの位置 ID を取得または設定します。
    /// </summary>
    public int Id { get; set; } = 0;

    /// <summary>
    /// バトル ダイス効果の説明を取得または設定します。
    /// </summary>
    public string BehaviourDesc { get; set; } = "";
}
