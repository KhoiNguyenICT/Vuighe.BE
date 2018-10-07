using Microsoft.EntityFrameworkCore.Migrations;

namespace Vuighe.Api.Migrations
{
    public partial class FullTextSearchTag : Migration
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

            migrationBuilder.Sql(@"create or replace function update_tag_ts_vector_trigger() returns trigger as $$
            begin
              new.""SearchVector"" := to_tsvector('simple', remove_accent(coalesce(new.""Name"", '')::text));
              return new;
            end;
                $$ LANGUAGE plpgsql;
            ");

            migrationBuilder.Sql(@"CREATE TRIGGER tag_search_vector_update BEFORE INSERT OR UPDATE
                ON ""Tags"" FOR EACH ROW EXECUTE PROCEDURE
                update_tag_ts_vector_trigger(""SearchVector"", 'pg_catalog.simple', ""Name"");");

            // force update
            migrationBuilder.Sql("UPDATE \"Tags\" SET \"Name\" = \"Name\";");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER tag_search_vector_update on ""Tags""");
            migrationBuilder.Sql(@"drop function update_tag_ts_vector_trigger");
        }
    }
}
