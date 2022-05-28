namespace RuinaDataCatalog.RuinaDBSetup.Models;

/// <summary>
/// バトル ページのバトル ダイスの振る舞い情報を格納します。
/// </summary>
public class CardBehaviourInfo
{
    /// <summary>
    /// 出目の最小値を取得または設定します。
    /// </summary>
    public int Min { get; set; } = 0;

    /// <summary>
    /// 出目の最大値を取得または設定します。
    /// </summary>
    public int Dice { get; set; } = 0;

    /// <summary>
    /// 振る舞いの種類を取得または設定します。
    /// </summary>
    public int Type { get; set; } = 0;

    /// <summary>
    /// 振る舞いの詳細を取得または設定します。
    /// </summary>
    public int Detail { get; set; } = 0;

    /// <summary>
    /// バトル ダイス使用時のキャラクターのモーションを取得または設定します。
    /// </summary>
    public int Motion { get; set; } = 0;

    /// <summary>
    /// MotionDefault を取得または設定します。
    /// </summary>
    public int MotionDefault { get; set; } = 0;

    /// <summary>
    /// バトル ダイス使用時のエフェクト名を取得または設定します。
    /// </summary>
    public string EffectRes { get; set; } = "";

    /// <summary>
    /// バトル ダイス効果の名前を取得または設定します。DiceCardAbility_xxx の xxx 部分に該当します。
    /// </summary>
    public string Script { get; set; } = "";

    /// <summary>
    /// バトル ダイス使用時のキャラクターおよびエフェクトの動作スクリプト名を取得または設定します。BehaviourAction_xxx の xxx 部分に該当します。
    /// </summary>
    public string ActionScript { get; set; } = "";

    /// <summary>
    /// 既定のバトル ダイス効果の説明を取得または設定します。
    /// </summary>
    public string Desc { get; set; } = "";
}
