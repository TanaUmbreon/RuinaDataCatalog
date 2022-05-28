namespace RuinaDataCatalog.Core.Models;

/// <summary>
/// バトル ページ情報を格納します。
/// </summary>
public class CardInfo
{
    /// <summary>
    /// バトル ページの数値 ID を取得または設定します。
    /// </summary>
    public int Id { get; set; } = 0;

    /// <summary>
    /// 既定のバトル ページ名を取得または設定します。
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// <see cref="Id">Id</see> と異なる値を使用する場合でのローカライズ テキスト ID を取得または設定します。
    /// </summary>
    public int TextId { get; set; } = -1;

    /// <summary>
    /// アートワーク名を取得または設定します。
    /// </summary>
    public string Artwork { get; set; } = "";

    /// <summary>
    /// レアリティを取得または設定します。
    /// </summary>
    public int Rarity { get; set; } = 0;

    /// <summary>
    /// 攻撃範囲を取得または設定します。
    /// </summary>
    public int Range { get; set; } = 0;

    /// <summary>
    /// コストを取得または設定します。
    /// </summary>
    public int Cost { get; set; } = 0;

    /// <summary>
    /// 使用対象を取得または設定します。
    /// </summary>
    public int Affection { get; set; } = 0;

    /// <summary>
    /// EmotionLimit を取得または設定します。
    /// </summary>
    public int EmotionLimit { get; set; } = 0;

    /// <summary>
    /// バトル ページ効果の名前を取得または設定します。
    /// </summary>
    public string Script { get; set; } = "";

    /// <summary>
    /// 既定のバトル ページ効果の説明を取得または設定します。
    /// </summary>
    public string ScriptDesc { get; set; } = "";

    /// <summary>
    /// 所属するチャプターを取得または設定します。
    /// </summary>
    public int Chapter { get; set; } = 0;
    /// <summary>
    /// SpecialEffect を取得または設定します。
    /// </summary>
    public string SpecialEffect { get; set; } = "";

    /// <summary>
    /// バトル ページ使用時、一時的に変更するキャラクター スキン名を取得または設定します。
    /// </summary>
    public string SkinChange { get; set; } = "";

    /// <summary>
    /// SkinChangeType を取得または設定します。
    /// </summary>
    public int SkinChangeType { get; set; } = 0;

    /// <summary>
    /// SkinHeight を取得または設定します。
    /// </summary>
    public int SkinHeight { get; set; } = 0;

    /// <summary>
    /// バトル ページ使用時、一時的に変更する背景マップの名前を取得または設定します。
    /// </summary>
    public string MapChange { get; set; } = "";

    /// <summary>
    /// 自動ターゲッティングで使用するバトル ページの使用優先度を取得または設定します。数値が高いほど優先的に使用します。
    /// </summary>
    public int Priority { get; set; } = 0;

    /// <summary>
    /// バトル ページの使用優先度を動的に決定するスクリプトの名前を取得または設定します。
    /// </summary>
    public string PriorityScript { get; set; } = "";

    /// <summary>
    /// Category を取得または設定します。
    /// </summary>
    public int Category { get; set; } = 0;

    /// <summary>
    /// 使用した E.G.O ページが再使用できるようになるまでの最大クールタイム値を取得または設定します。
    /// </summary>
    public int MaxCooltimeForEgo { get; set; } = 0;

    /// <summary>
    /// MaxNum を取得または設定します。
    /// </summary>
    public int MaxNum { get; set; } = 0;

    /// <summary>
    /// バトル ページに付与されたオプションのコレクションを取得または設定します。
    /// </summary>
    public IEnumerable<int> Option { get; set; } = Array.Empty<int>();

    /// <summary>
    /// ヘルプ メッセージ用キーワードのコレクションを取得または設定します。
    /// </summary>
    public IEnumerable<string> Keyword { get; set; } = Array.Empty<string>();

    /// <summary>
    /// バトル ダイスの振る舞いのコレクションを取得または設定します。
    /// </summary>
    public IEnumerable<CardBehaviourInfo> Behaviour { get; set; } = Array.Empty<CardBehaviourInfo>();
}
