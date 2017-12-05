using FluentMigrator;

namespace Bunt.Migrations
{
    [Migration(201712051338)]
    public class AddBuntladeStalleTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("BuntladeStalle")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("Index").AsInt32()
                .WithColumn("Adress").AsString()
                .WithColumn("Typ").AsInt32()
                .WithColumn("Buntladenummer").AsInt32().Nullable();
        }
    }
}