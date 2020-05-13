using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace DndExample
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var border = this.FindControl<Border>("DropArea");
            border.AddHandler(DragDrop.DragOverEvent, OnDragOver);
            border.AddHandler(DragDrop.DropEvent, OnDrop);
        }

        private void OnDrop(object? sender, DragEventArgs e)
        {
            var tb = this.FindControl<TextBox>("TextBox");
            if (e.Data.Contains(DataFormats.FileNames))
                tb.Text = string.Join("\n", e.Data.GetFileNames());
            else if (e.Data.Contains(DataFormats.Text))
                tb.Text = e.Data.GetText();
            else
                tb.Text = "Unsupported format";
        }

        private void OnDragOver(object? sender, DragEventArgs e)
        {
            e.DragEffects = e.DragEffects & DragDropEffects.Copy;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}