using FluentMigrator;

namespace database_migration
{

    [Migration(202210192107)]
    public class CreateTableGoods : Migration
    {
        public override void Up()
        {
            Create.Table("goods")
                .WithColumn("Id").AsGuid().PrimaryKey().Identity()
                .WithColumn("name").AsString()
                .WithColumn("desc").AsString();
        }

        public override void Down()
        {
            Delete.Table("goods");
        }
    }
}