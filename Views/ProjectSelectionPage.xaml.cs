using HKLS_App.Models;
using HKLS_App.Data;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;
using System.Linq;

namespace HKLS_App.Views
{
    public partial class ProjectSelectionPage : ContentPage
    {
        private readonly ApplicationDbContext _context;

        public ProjectSelectionPage(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;

            // Load projects from the database into the Picker
            var projects = _context.Projects.ToList();
            projectPicker.ItemsSource = projects;
            projectPicker.ItemDisplayBinding = new Binding("Name"); // Display the project name
        }

        private async void OnUploadClicked(object sender, EventArgs e)
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Pdf, // Assuming IFC models can be uploaded as files
                PickerTitle = "Select IFC Model"
            });

            if (result != null)
            {
                var selectedProject = (Project)projectPicker.SelectedItem;
                if (selectedProject != null)
                {
                    // Update the project with the selected IFC file path
                    selectedProject.IFCFilePath = result.FullPath;
                    _context.Projects.Update(selectedProject);
                    await _context.SaveChangesAsync();

                    await DisplayAlert("Success", $"IFC model uploaded for {selectedProject.Name}", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Please select a project first.", "OK");
                }
            }
        }

        private async void OnContinueClicked(object sender, EventArgs e)
        {
            var selectedProject = (Project)projectPicker.SelectedItem;
            if (selectedProject != null)
            {
                // Navigate to another page or continue with the project-specific operations
                await DisplayAlert("Project Selected", $"You selected {selectedProject.Name}", "OK");
                // Navigate to another page to display the IFC model or more project details
            }
            else
            {
                await DisplayAlert("Error", "Please select a project.", "OK");
            }
        }
    }
}
