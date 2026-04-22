using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WaveCylinderApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public double BaseRadius { get; set; }

        [BindProperty]
        public double Amplitude { get; set; }

        [BindProperty]
        public double Frequency { get; set; }

        [BindProperty]
        public double Height { get; set; }

        public double VolumeResult { get; set; }

        public void OnPost()
        {
            VolumeResult = CalculateVolume(BaseRadius, Amplitude, Frequency, Height);
        }

        // AI-inspired numerical integration
        private double CalculateVolume(double R, double A, double k, double H)
        {
            int slices = 10000; // high accuracy
            double dz = H / slices;
            double volume = 0;

            for (int i = 0; i < slices; i++)
            {
                double z = i * dz;
                double radius = R + A * Math.Sin(k * z);
                double area = Math.PI * radius * radius;
                volume += area * dz;
            }

            return volume;
        }
    }
}