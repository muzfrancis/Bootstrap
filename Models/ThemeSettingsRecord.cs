namespace Bootstrap.Models {
    public class ThemeSettingsRecord {
        public ThemeSettingsRecord() {
            this.Swatch = Constants.SWATCH_CSS_DEFAULT;
            this.UseFixedHeader = true;
            this.UseInverseHeader = false;
            this.UseStickyFooter = true;
        }

        public virtual int Id { get; set; }
        public virtual string Swatch { get; set; }
        public virtual bool UseFixedHeader { get; set; }
        public virtual bool UseInverseHeader { get; set; }
        public virtual bool UseStickyFooter { get; set; }
    }
}