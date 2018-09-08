using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

namespace Vuighe.Api.Migrations
{
    public partial class FullTextSearchCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                    name: "IX_Categories_SearchVector",
                    table: "Categories",
                    column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

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

            migrationBuilder.Sql(@"create or replace function update_category_ts_vector_trigger() returns trigger as $$
            begin
              new.""SearchVector"" := to_tsvector('simple', remove_accent(coalesce(new.""Title"", '')::text));
              return new;
            end;
                $$ LANGUAGE plpgsql;
            ");

            migrationBuilder.Sql(@"CREATE TRIGGER category_search_vector_update BEFORE INSERT OR UPDATE
                ON ""Categories"" FOR EACH ROW EXECUTE PROCEDURE
                update_category_ts_vector_trigger(""SearchVector"", 'pg_catalog.simple', ""Title"");");

            // force update
            migrationBuilder.Sql("UPDATE \"Categories\" SET \"Title\" = \"Title\";");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER category_search_vector_update on ""Categories""");
            migrationBuilder.Sql(@"drop function update_category_ts_vector_trigger");
        }
    }
}
