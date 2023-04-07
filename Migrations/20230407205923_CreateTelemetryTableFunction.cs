using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSence.Migrations
{
    /// <inheritdoc />
    public partial class CreateTelemetryTableFunction : Migration
    {
        /// <inheritdoc />

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE OR REPLACE FUNCTION CreateTelemetryTable(\r\n  table_name text,\r\n  columns text[],\r\n  types text[]\r\n) RETURNS void AS $$\r\nDECLARE\r\n  col_count INTEGER;\r\n  i INTEGER := 1;\r\n  query text := 'CREATE TABLE ' || table_name || ' (';\r\nBEGIN\r\n  col_count := array_length(columns, 1);\r\n  IF col_count <> array_length(types, 1) THEN\r\n    RAISE EXCEPTION 'Number of columns and data types must match';\r\n  END IF;\r\n  \r\n  WHILE i <= col_count LOOP\r\n    query := query || columns[i] || ' ' || types[i] || ',';\r\n    i := i + 1;\r\n  END LOOP;\r\n  \r\n  query := rtrim(query, ',') || ')';\r\n  EXECUTE query;\r\nEND;\r\n$$ LANGUAGE plpgsql;");
        }



        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS CreateTelemetryTable();");
        }

    }
}
