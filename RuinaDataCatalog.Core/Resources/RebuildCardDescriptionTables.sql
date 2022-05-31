-- バトル ページ説明で使用するテーブル群を再構築するクエリです。

-- バトル ページ説明テーブル:
--   ローカライズされたバトル ページ説明情報を定義します。
--   "CARD"."TEXT_ID" と "CARD_DESC"."ID" で結合してどのバトル ページに対する定義なのかを表します。
--   ただし、"CARD"."TEXT_ID" が -1 の場合は "CARD"."ID" と結合します。
DROP TABLE IF EXISTS "CARD_DESC";
CREATE TABLE "CARD_DESC" (
    "ID" INTEGER NOT NULL,
    "LOCALIZED_NAME" TEXT NOT NULL,
    "ABILITY" TEXT NOT NULL,
    PRIMARY KEY("ID")
);

-- バトル ページ ダイス振る舞い説明テーブル
--   バトル ページが持つ、ローカライズされたバトル ダイスの振る舞い説明を定義します。
--   "CARD_DESC"."ID" と "CARD_BEHAVIOUR_DESC"."CARD_DESC_ID" で結合してどのバトル ページ説明に対する定義なのかを表し、
--   "CARD_BEHAVIOUR_DESC"."INDEX" の値でバトル ダイスのどの位置に紐づくかを定義します。
DROP TABLE IF EXISTS "CARD_BEHAVIOUR_DESC";
CREATE TABLE "CARD_BEHAVIOUR_DESC" (
    "CARD_DESC_ID" INTEGER NOT NULL,
    "INDEX" INTEGER NOT NULL,
    "BEHAVIOUR_DESC" TEXT NOT NULL,
    PRIMARY KEY("CARD_DESC_ID", "INDEX")
);
