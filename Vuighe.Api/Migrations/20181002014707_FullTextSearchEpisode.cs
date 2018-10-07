using Microsoft.EntityFrameworkCore.Migrations;

namespace Vuighe.Api.Migrations
{
    public partial class FullTextSearchEpisode : Migration
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

            migrationBuilder.Sql(@"create or replace function update_episode_ts_vector_trigger() returns trigger as $$
            begin
              new.""SearchVector"" := to_tsvector('simple', remove_accent(coalesce(new.""Title"", '')::text));
              return new;
            end;
                $$ LANGUAGE plpgsql;
            ");

            migrationBuilder.Sql(@"CREATE TRIGGER episode_search_vector_update BEFORE INSERT OR UPDATE
                ON ""Episodes"" FOR EACH ROW EXECUTE PROCEDURE
                update_episode_ts_vector_trigger(""SearchVector"", 'pg_catalog.simple', ""Title"");");

            // force update
            migrationBuilder.Sql("UPDATE \"Episodes\" SET \"Title\" = \"Title\";");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER episode_search_vector_update on ""Episodes""");
            migrationBuilder.Sql(@"drop function update_episode_ts_vector_trigger");
        }
    }
}
