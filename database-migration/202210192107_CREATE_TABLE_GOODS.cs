using FluentMigrator;

namespace database_migration
{

    [Migration(202210192107)]
    public class CreateTableGoods : Migration
    {
        public override void Up()
        {
            Create.Table("goods")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("name").AsString()
                .WithColumn("description").AsString();
        }

        public override void Down()
        {
            Delete.Table("goods");
        }
    }
}