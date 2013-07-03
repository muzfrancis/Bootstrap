namespace Bootstrap.Models {
    public class ThemeSettingsRecord {
        public ThemeSettingsRecord() {
            this.Swatch = Constants.SWATCH_CSS_DEFAULT;
        }

        public virtual int Id { get; set; }
        public virtual string Swatch { get; set; }
    }
}