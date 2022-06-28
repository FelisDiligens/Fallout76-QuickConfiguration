namespace Fo76ini
{
    partial class FormMain
    {
        public void OnLanguageChanged(object sender, TranslationEventArgs e)
        {
            Translation translation = (Translation)sender;

            // Set labels and stuff:
            this.labelTranslationAuthor.Visible = e.HasAuthor;
            this.labelTranslationBy.Visible = e.HasAuthor;
            this.labelTranslationAuthor.Text = e.HasAuthor ? translation.Author : "";

            // TODO: UpdateUI?
            this.CheckVersion();

            this.Refresh(); // Forces redraw
        }
        // TODO: FormMods needs OnLanguageChanged code.
        // formMods.UpdateUI(); // TODO: Changing the language before loading mods crashes the tool on startup.
    }
}
