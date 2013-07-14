using Orchard.Data.Migration;

namespace Bootstrap {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable("ThemeSettingsRecord", table => table
                .Column<int>("Id", column => column.PrimaryKey().Identity())
                .Column<string>("Swatch", c => c.WithLength(50).WithDefault(Constants.SWATCH_CSS_DEFAULT))
                .Column<bool>("UseFixedNav")
                .Column<bool>("UseNavSearch")
                .Column<bool>("UseFluidLayout")
                .Column<bool>("UseInverseNav")
                .Column<bool>("UseStickyFooter")
            );

            return 1;
        }
    }
}