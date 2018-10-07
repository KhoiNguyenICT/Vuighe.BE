using Microsoft.EntityFrameworkCore.Migrations;

namespace Vuighe.Api.Migrations
{
    public partial class FullTextSearchAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR REPLACE FUNCTION remove_accent(input text)
              RETURNS text
              IMMUTABLE
              STRICT
              LANGUAGE SQL
            AS $$
              SELECT translate(
                input,
                'áàảãạâấầẩẫậăắằẳẵặäåāąÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶÄÅĀĄéèẻẽẹêếềểễệëēĕėęÉÈẺẼẸÊẾỀỂỄỆËĒĔĖĘiíìỉĩịîïĩīĭIÍÌỈĨỊÎÏĨĪĬóòỏõọơớờởỡợôốồổỗộöōŏőÓÒỎÕỌƠỚỜỞỠỢÔỐỒỔỖỘÖŌŎŐùúûüũūŭůủụưứừửữựÙÚÛÜŨŪŬŮỦỤƯỨỪỬỮỰyýỳỷỹỵYÝỲỶỸỴđĐ',
                'aaaaaaaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAeeeeeeeeeeeeeeeeEEEEEEEEEEEEEEEEiiiiiiiiiiiIIIIIIIIIIIoooooooooooooooooooooOOOOOOOOOOOOOOOOOOOOOuuuuuuuuuuuuuuuuUUUUUUUUUUUUUUUUyyyyyyYYYYYYdD'
              );
            $$;");

            migrationBuilder.Sql(@"create or replace function update_asset_ts_vector_trigger() returns trigger as $$
            begin
              new.""SearchVector"" := to_tsvector('simple', remove_accent(coalesce(new.""FileName"", '')::text));
              return new;
            end;
                $$ LANGUAGE plpgsql;
            ");

            migrationBuilder.Sql(@"CREATE TRIGGER asset_search_vector_update BEFORE INSERT OR UPDATE
                ON ""Assets"" FOR EACH ROW EXECUTE PROCEDURE
                update_asset_ts_vector_trigger(""SearchVector"", 'pg_catalog.simple', ""FileName"");");

            // force update
            migrationBuilder.Sql("UPDATE \"Assets\" SET \"FileName\" = \"FileName\";");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER asset_search_vector_update on ""Assets""");
            migrationBuilder.Sql(@"drop function update_asset_ts_vector_trigger");
        }
    }
}
