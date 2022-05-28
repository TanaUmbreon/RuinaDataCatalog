﻿using RuinaDataCatalog.RuinaDBSetup.Models;
using RuinaDataCatalog.RuinaDBSetup.Repositries;

namespace RuinaDataCatalog.RuinaDBSetup.Infrastructures.Sqlite;

/// <summary>
/// SQLite データベース ファイルで構成された Ruina カタログ データベースをセットアップするための直接的な操作を提供します。
/// </summary>
public class SqliteCatalogSetupRepository : ICatalogSetupRepository
{
    private readonly FileInfo _dbFile;

    /// <summary>
    /// <see cref="SqliteCatalogSetupRepository"/> の新しいインスタンスを生成します。
    /// </summary>
    /// <param name="writingFilePath">書き出し先となる Ruina カタログ データベースのパス。</param>
    /// <param name="overwrites">書き出し先にファイルが存在した時、上書きすることを表す値。</param>
    public SqliteCatalogSetupRepository(string writingFilePath, bool overwrites)
    {
        if (writingFilePath == null) { throw new ArgumentNullException(nameof(writingFilePath)); }

        _dbFile = new FileInfo(writingFilePath);
        if (!overwrites && _dbFile.Exists) { throw new InvalidOperationException("出力先に既にファイルがあります。上書き出力する場合はオプションを指定してください。"); }

        _dbFile.Directory?.Create();
    }

    public void RebuildAndInsertEnumDescriptions()
    {
        throw new NotImplementedException();
    }

    public void SetupCardDescriptions(IEnumerable<CardDescriptionInfo> cardDescriptions)
    {
        throw new NotImplementedException();
    }

    public void SetupCards(IEnumerable<CardInfo> cards)
    {
        throw new NotImplementedException();
    }
}