using FluentMigrator;

namespace database_migration
{

    [Migration(202210192057)]
    public class CreateTableOrder : Migration
    {
        public override void Up()
        {
            Create.Table("order")
                .WithColumn("Id").AsGuid().PrimaryKey().Identity()
                .WithColumn("goods_id").AsGuid()
                .WithColumn("status").AsString()
                .WithColumn("username").AsString()
                .WithColumn("desc").AsString();
        }

        public override void Down()
        {
            Delete.Table("order");
        }
    }
}