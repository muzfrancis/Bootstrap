using Orchard.Data.Migration;

namespace Bootstrap {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable("ThemeSettingsRecord", table => table
                .Column<int>("Id", column => column.PrimaryKey().Identity())
                .Column<string>("Swatch", c => c.WithLength(50).WithDefault(Constants.SWATCH_CSS_DEFAULT))
                .Column<bool>("UseFixedHeader")
                .Column<bool>("UseFluidLayout")
                .Column<bool>("UseInverseHeader")
                .Column<bool>("UseStickyFooter")
            );

            return 1;
        }
    }
}