using Microsoft.EntityFrameworkCore.Migrations;

namespace Vuighe.Api.Migrations
{
    public partial class FullTextSearchFilm : Migration
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

            migrationBuilder.Sql(@"create or replace function update_film_ts_vector_trigger() returns trigger as $$
            begin
              new.""SearchVector"" := to_tsvector('simple', remove_accent(coalesce(new.""Title"", '')::text));
              return new;
            end;
                $$ LANGUAGE plpgsql;
            ");

            migrationBuilder.Sql(@"CREATE TRIGGER film_search_vector_update BEFORE INSERT OR UPDATE
                ON ""Films"" FOR EACH ROW EXECUTE PROCEDURE
                update_film_ts_vector_trigger(""SearchVector"", 'pg_catalog.simple', ""Title"");");

            // force update
            migrationBuilder.Sql("UPDATE \"Films\" SET \"Title\" = \"Title\";");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER film_search_vector_update on ""Films""");
            migrationBuilder.Sql(@"drop function update_film_ts_vector_trigger");
        }
    }
}
